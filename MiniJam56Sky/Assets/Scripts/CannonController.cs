using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    bool readyToFire;
    bool fire;

    [SerializeField] private float fireRate = 10f;
    [SerializeField] private float firePower = 1000f;
    private float fireTimer = 0f;
    public GameObject donutPrefab;
    public AudioClip clip;
    public SFXPlayer sfxPlayer;

    // You must set the cursor in the inspector.
    public Texture2D crosshair;

    void Start()
    {

        //set the cursor origin to its centre. (default is upper left corner)
        Vector2 cursorOffset = new Vector2(crosshair.width / 2, crosshair.height / 2);

        //Sets the cursor to the Crosshair sprite with given offset 
        //and automatic switching to hardware default if necessary
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }
        if (!readyToFire)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= 1 / fireRate)
            {
                readyToFire = true;
            }
        }
        //fire = false;
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
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Instantiate donut
            var donut = Instantiate(donutPrefab, transform.position, Quaternion.identity, null) as GameObject;
            //Fire Donut
            donut.GetComponent<Rigidbody2D>().AddForce(firePower * transform.right);
            //Play sound
            sfxPlayer.PlayAudio(clip);
            readyToFire = false;
            fire = false;
            fireTimer = 0f;
        }

    }
}
