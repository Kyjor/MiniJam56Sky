using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private float cloudMinSize = 1f;
    [SerializeField] private float cloudMaxSize = 4f;
    [SerializeField] private float cloudMinSpeed = .5f;
    [SerializeField] private float cloudMaxSpeed = 3.5f;
    public float[] cloudSpawnWeights;
    public float moveSpeed;
    public bool right = false;
    public Sprite[] cloudSprites;
    // Start is called before the first frame update
    void Start()
    {   
        GetComponent<SpriteRenderer>().sprite = cloudSprites[GetRandomWeightedIndex(cloudSpawnWeights)];
        moveSpeed = Random.Range(cloudMinSpeed,cloudMaxSpeed);
        transform.localScale *= Random.Range(cloudMinSize,cloudMaxSize);
        InvokeRepeating("MoveCloud",0f, Time.deltaTime);
        Invoke("DestroyThis",20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCloud()
    {
        if(right)
        {
        transform.Translate(Vector3.left*Time.deltaTime*moveSpeed);
        }
        else if (!right)
        {
            transform.Translate(Vector3.right*Time.deltaTime*moveSpeed);

        }
    }
    void DestroyThis()
    {
        Destroy(gameObject);
    }

     public int GetRandomWeightedIndex(float[] weights)
            {
                if (weights == null || weights.Length == 0) return 0;
     
                float w;
                float t = 0;
                int i;
                for (i = 0; i < weights.Length; i++)
                {
                    w = weights[i];
     
                    if (float.IsPositiveInfinity(w))
                    {
                        return i;
                    }
                    else if (w >= 0f && !float.IsNaN(w))
                    {
                        t += weights[i];
                    }
                }
     
                float r = Random.Range(0,t);
                float s = 0f;
     
                for (i = 0; i < weights.Length; i++)
                {
                    w = weights[i];
                    if (float.IsNaN(w) || w <= 0f) continue;
     
                    s += w / t;
                    if (s >= r) return i;
                }
     
                return 0;
            }
}
