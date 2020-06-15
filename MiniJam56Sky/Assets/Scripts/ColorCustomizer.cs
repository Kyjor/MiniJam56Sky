using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCustomizer : MonoBehaviour
{
    public GameObject[] spriteArms;
    public GameObject [] spriteShirts;
    public GameObject[] spriteHairs;
    // Start is called before the first frame update
    void Start()
    {
        ColorSprites();
    }


    void ColorSprites()
    {   Color newColor = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f), Random.Range(0f, 1f));
        for (int i = 0; i < spriteArms.Length; i++)
        {
             // Color part
            
            spriteArms[i].GetComponent<SpriteRenderer>().color = newColor;
        }
        newColor = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f), Random.Range(0f, 1f));
         for (int i = 0; i < spriteShirts.Length; i++)
        {
             // Color part
            
            spriteShirts[i].GetComponent<SpriteRenderer>().color = newColor;
        }
        newColor = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f), Random.Range(0f, 1f));
         for (int i = 0; i < spriteHairs.Length; i++)
        {
             // Color part
            
            spriteHairs[i].GetComponent<SpriteRenderer>().color = newColor;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
