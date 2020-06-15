using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionCollider : MonoBehaviour
{
    public EnemyAttack enemyAttack;
    [Header("Events")]
	[Space]
    public UnityEvent OnPlayerDetectedEvent;
    private void Awake() {
        {
            if(OnPlayerDetectedEvent == null)
            {
                OnPlayerDetectedEvent = new UnityEvent();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        print(other.name);
        if(other.gameObject.CompareTag("Base"))
        {
            print("Helllloooo");

            OnPlayerDetectedEvent.Invoke();
            enemyAttack.target = other.gameObject.transform;
        }
    }
}
