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

    public bool isFactory;
    public GameObject restartButton;

    private void Start()
    {
        this.maxHealth = this.health;
    }

    private void Update()
    {   if(healthDisplay != null)
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
<<<<<<< HEAD
            if (isFactory)
            {
                restartButton.SetActive(true);
            }
            // game over
            
            else if(!isFactory)
                Destroy(gameObject);
            
=======
            restartButton.SetActive(true);
            // game over
            if (!isFactory)
            {
                Destroy(gameObject);
            }
>>>>>>> master
        }
    }
    public void BuyHealth()
    {
        if (PointManager.Instance.SpendPoints(100) && health <= maxHealth)
        {
            this.health += 100;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
            float fill = this.health/this.maxHealth;
            healthBar.fillAmount = fill;
        }
    }
}
