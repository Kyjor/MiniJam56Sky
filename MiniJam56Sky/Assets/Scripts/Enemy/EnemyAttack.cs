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
        newBullet.GetComponent<Rigidbody2D>().AddForce(transform.right*attackPower*transform.localScale.x);
        fireTimer = 0f;
        fire = false;    
    }
}
