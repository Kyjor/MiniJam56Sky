using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{

    public void PlayAudio(AudioClip clip)
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
    }
}
