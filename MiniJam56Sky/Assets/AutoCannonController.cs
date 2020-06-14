using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonController : MonoBehaviour
{
    bool readyToFire;
    bool fire;
    bool isBeingPlaced;
    bool isGroundTower;
    [SerializeField] private float fireRate = 10f;
    [SerializeField] private float firePower = 1000f;
    private float fireTimer = 0f;
    public GameObject donutPrefab;
    public Transform target;

    void Start()
    {
        isBeingPlaced = true;
    }



    void Update()
    {
        if(isBeingPlaced)
        {
            //set alpha to .5

            //follow mouse
        if (Input.GetMouseButtonDown(0))
        {
            //place object (y position Set)
            if(isGroundTower)
            {
                //place on selected x pos on the groud, activate
            }
            else if (!isGroundTower)
            {
                //place on selected x in the air
            }
            //release control
            isBeingPlaced = false;
        }
        }

        if (!readyToFire)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= 1 / fireRate)
            {
                readyToFire = true;
            }
        }
       else if ( readyToFire && !fire)
       {
           fire = true;
       }
       AimCannon();
    }

    void AimCannon()
    {
        if(target !=null)
            {
                Vector3 dir = target.position -  transform.position;
                print(dir);
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
    }

    private void FixedUpdate()
    {
        if (fire && readyToFire)
        {
            FireCannon();
        }
    }
    void FireCannon()
    {

        if (readyToFire)
        {
            if(target !=null)
            {
            
            
              //Instantiate donut
                var donut = Instantiate(donutPrefab, transform.position, Quaternion.identity, null) as GameObject;
                //Fire Donut
                donut.GetComponent<Rigidbody2D>().AddForce(firePower * transform.right);
                readyToFire = false;
                fire = false;
                fireTimer = 0f;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Enemy"))
        {
            target = collider2D.gameObject.transform;
        }
    }
}
