using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCustomizer : MonoBehaviour
{
    public GameObject[] spriteParts;
    // Start is called before the first frame update
    void Start()
    {
        ColorSprites();
    }


    void ColorSprites()
    {
        for (int i = 0; i < spriteParts.Length; i++)
        {
             // Color part
            Color newColor = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f), Random.Range(0f, 1f));
            spriteParts[i].GetComponent<SpriteRenderer>().color = newColor;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
