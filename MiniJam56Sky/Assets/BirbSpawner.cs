using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbSpawner : MonoBehaviour
{
    public Transform leftTop;
    public Transform leftBottom;
    public Transform rightTop;
    public Transform rightBottom;

    public GameObject birbPrefab;
    public GameObject birbHolder;
  
    [SerializeField] private float timeBetweenSpawns = .5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBirb",0, timeBetweenSpawns);
    }

    void SpawnBirb()
    {
        var newPosition = Vector3.zero;
        bool right = System.Convert.ToBoolean(Random.Range(0,2));
        if(right)
        {
            newPosition = new Vector3(rightBottom.position.x,Random.Range(rightBottom.position.y,rightTop.position.y), 1f );
        }
        else if(!right)
        {
                        newPosition = new Vector3(leftBottom.position.x,Random.Range(rightBottom.position.y,rightTop.position.y), 1f );

        }
        var newBirb = Instantiate(birbHolder,transform.position,Quaternion.identity, birbHolder.transform) as GameObject;
        newBirb.GetComponent<BirbController>().right = right;
        newBirb.transform.position = newPosition;
    }
    
}
