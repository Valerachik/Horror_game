using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuk_music : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            if (audioSource != null && clip != null)
            {
                audioSource.PlayOneShot(clip);
                hasPlayed = true;
            }
        }
    }

}
