using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{   
    public bool attack;
    bool fire;
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private float fireTimer = 0f;
    [SerializeField] private float attackPower = 500f;
    [SerializeField] private float attackDistance = 1f;

    public Transform bulletOrigin;
    public GameObject bulletPrefab;

    public Transform target;

    private void Start()
    {
        this.target = GameObject.FindGameObjectWithTag("Base").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(attack)
        {
            if(fireTimer < 1f/fireRate)
            {
                fireTimer += Time.deltaTime;
            }
            else
            {
                fire = true;
            }
        }
    }
    private void FixedUpdate() 
    {
        if (fire)
        {
            Fire();
        }        
    }

    public void Fire()
    {
        var newBullet = Instantiate(bulletPrefab, bulletOrigin.position, Quaternion.identity, null) as GameObject;
        //newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right*attackPower*transform.localScale.x);
        Vector2 targetVector = new Vector2(this.target.transform.position.x, this.target.transform.position.y) -
            new Vector2(transform.position.x, transform.position.y);
        newBullet.GetComponent<Rigidbody2D>().AddForce(targetVector * attackPower);
        fireTimer = 0f;
        fire = false;
    }
}
