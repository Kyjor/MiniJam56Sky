using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
    public float health;
    private float maxHealth;

    public TextMeshProUGUI healthDisplay;

    private void Start()
    {
        this.maxHealth = this.health;
    }

    private void Update()
    {
        this.healthDisplay.text = this.health.ToString() + "/" + this.maxHealth.ToString();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("took damge" + damage);
        this.health -= damage;
        if (health <= 0)
        {
            // game over
        }
    }
}
