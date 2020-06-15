using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannonController : MonoBehaviour
{
    bool readyToFire;
    bool fire;
    bool isBeingPlaced;
    [SerializeField] bool isGroundTower;
    [SerializeField] private float fireRate = 10f;
    [SerializeField] private float firePower = 1000f;
    private float groundTowerYPosition = -3.75f;
    private float airTowerYPosition = 3.75f;
    private float fireTimer = 0f;

    public float moveSpeed = 0.1f;   
    private Vector3 mousePosition;
    public GameObject donutPrefab;
    public Transform target;
    public Transform parentTransform;
    SpriteRenderer mySpriteRenderer;
    public SpriteRenderer factorySprite;

    void Start()
    {
        isBeingPlaced = true;
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(isBeingPlaced)
        {
            //set alpha to .5
            mySpriteRenderer.color = new Color(mySpriteRenderer.color.r,mySpriteRenderer.color.g, mySpriteRenderer.color.b, .5f);
            factorySprite.color = new Color(factorySprite.color.r,factorySprite.color.g, factorySprite.color.b, .5f);

            //follow mouse
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            parentTransform.position = Vector2.Lerp(parentTransform.position, mousePosition, moveSpeed);

            if (Input.GetMouseButtonDown(0))
            {
                //place object (y position Set)
                if(isGroundTower)
                {
                    //place on selected x pos on the ground, activate
                    parentTransform.position = new Vector3(parentTransform.position.x, groundTowerYPosition,0f);
                }
                else if (!isGroundTower)
                {
                    //place on selected x in the air
                    parentTransform.position = new Vector3(parentTransform.position.x, airTowerYPosition,0f);
                }
                //release control
                isBeingPlaced = false;
                //Reset Alpha
                mySpriteRenderer.color = new Color(mySpriteRenderer.color.r,mySpriteRenderer.color.g, mySpriteRenderer.color.b, 1f);
                factorySprite.color = new Color(factorySprite.color.r,factorySprite.color.g, factorySprite.color.b, 1f);
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
            //print(dir);
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
