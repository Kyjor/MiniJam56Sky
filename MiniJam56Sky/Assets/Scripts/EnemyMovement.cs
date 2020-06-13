using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private bool active;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.active)
        {
            // Move our position a step closer to the target.
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                // stop moving
                this.active = false;
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

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
