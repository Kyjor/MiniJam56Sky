using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public EnemyType type;

    public float maxHealth;
    public float health;
    public SFXPlayer sfxPlayer;
    public AudioClip deathClip;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public Image healthBar;
    void Start()
    {
        sfxPlayer = FindObjectOfType<SFXPlayer>();
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        this.health -= damage;
        float fill = this.health/this.maxHealth;
        healthBar.fillAmount = fill;
        if (health <= 0)
        {
            // die
            sfxPlayer.PlayAudio(deathClip);
            Destroy(this.gameObject, 0.001f);

            RoundManager.Instance.KillEnemy();


            PointManager.Instance.AddPoints(Random.Range(10,15));

        }
    }
}
