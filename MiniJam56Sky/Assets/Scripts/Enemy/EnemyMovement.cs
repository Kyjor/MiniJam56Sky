using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private bool active;
    private Transform target;
    private GameObject[] helicopterTargets;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Enemy>().type == EnemyType.Helicopter)
        {
            helicopterTargets = GameObject.FindGameObjectsWithTag("HelicopterTarget");
            this.SetTarget(this.helicopterTargets[Random.Range(0, helicopterTargets.Length - 1)].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.active)
        {
            // Move our position a step closer to the target.
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                // stop moving
                this.active = false;

                switch (GetComponent<Enemy>().type)
                {
                    case EnemyType.Helicopter:
                        StartCoroutine("FireAndMove");
                        break;
                    case EnemyType.Person:
                        GetComponent<EnemyAttack>().attack = true;
                        break;
                }
            }
        }
    }

    // sets the target to move to and activates movement
    public void SetTarget(Transform target)
    {
        this.target = target;
        this.active = true;
        if(this.target.position.x < transform.position.x)
        {
            Vector3 flipPlayerScale = transform.localScale;
            flipPlayerScale.x *= -1;
            transform.localScale = flipPlayerScale;
        }
    }

    private IEnumerator FireAndMove()
    {
        GetComponent<EnemyAttack>().attack = true;
        yield return new WaitForSeconds(2);
        GetComponent<EnemyAttack>().attack = false;

        this.SetTarget(this.helicopterTargets[Random.Range(0, helicopterTargets.Length-1)].transform);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
