using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
      public float maxHealth;
    public float health;
    public Image healthBar;

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
        float fill = this.health/this.maxHealth;
        healthBar.fillAmount = fill;
        if (health <= 0)
        {
            // game over
        }
    }
}
