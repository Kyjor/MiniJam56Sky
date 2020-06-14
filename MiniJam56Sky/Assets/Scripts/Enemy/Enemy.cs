using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;

    public float health;
    public SFXPlayer sfxPlayer;
    public AudioClip deathClip;
    public void TakeDamage(float damage)
    {
        this.health -= damage;
        if (health <= 0)
        {
            // die
            sfxPlayer.PlayAudio(deathClip);
            Destroy(this.gameObject, 0.001f);

            RoundManager.Instance.KillEnemy();
        }
    }
}
