using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public Transform leftTop;
    public Transform leftBottom;
    public Transform rightTop;
    public Transform rightBottom;

    public GameObject cloudPrefab;
    
  
    [SerializeField] private float timeBetweenSpawns = .5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCloud",0, timeBetweenSpawns);
    }

    void SpawnCloud()
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
        var newCloud = Instantiate(cloudPrefab,transform.position,Quaternion.identity, null) as GameObject;
        newCloud.GetComponent<CloudController>().right = right;
        newCloud.transform.position = newPosition;
    }
    
}
