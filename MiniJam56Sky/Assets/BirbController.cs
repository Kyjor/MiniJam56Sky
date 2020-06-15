using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbController : MonoBehaviour
{
    [SerializeField] private float birbMinSize = 1f;
    [SerializeField] private float birbMaxSize = 4f;
    [SerializeField] private float birbMinSpeed = .5f;
    [SerializeField] private float birbMaxSpeed = 3.5f;
    public float moveSpeed;
    public bool right = false;
    // Start is called before the first frame update
    void Start()
    {   
        moveSpeed = Random.Range(birbMinSpeed,birbMaxSpeed);
        transform.localScale *= Random.Range(birbMinSize,birbMaxSize);
        InvokeRepeating("Movebirb",0f, Time.deltaTime);
        Invoke("DestroyThis",30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movebirb()
    {
        if(right)
        {
            
        transform.Translate(Vector3.left*Time.deltaTime*moveSpeed);
        }
        else if (!right)
        {
            transform.Translate(Vector3.right*Time.deltaTime*moveSpeed);
            Vector3 flipPlayerScale = transform.localScale;
            flipPlayerScale.x *= -1;
            transform.localScale = flipPlayerScale;
        }
    }
    void DestroyThis()
    {
        Destroy(gameObject);
    }

     
}
