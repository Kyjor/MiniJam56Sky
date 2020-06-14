using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionCollider : MonoBehaviour
{
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
        if(other.gameObject.CompareTag("Player"))
        {
            OnPlayerDetectedEvent.Invoke();
        }
    }
}
