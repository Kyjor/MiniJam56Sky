using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    private bool canDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && canDamage)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(this.damage);
            canDamage = false;
            Destroy(gameObject);

        }

        if (collision.CompareTag("Base") && canDamage)
        {
            collision.gameObject.GetComponent<Base>().TakeDamage(this.damage);
            canDamage = false;
            Destroy(gameObject);

        }
    }
}
