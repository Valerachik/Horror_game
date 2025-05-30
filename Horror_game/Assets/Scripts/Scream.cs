using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip ClipFx;

    private void OnTriggerEnter(Collider other)
    {

        if (CompareTag("screamer") && other.CompareTag("Player"))
        {
           myFx.PlayOneShot(ClipFx);
        }
    }
    public void OnScreamAnimationEnd()
    {
        gameObject.SetActive(false);
    }
}
