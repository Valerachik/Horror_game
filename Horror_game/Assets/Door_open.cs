using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip firstSound;
    public AudioClip secondSound;

    private bool firstSoundPlayed = false;

    // Метод для програвання першого звуку
    public void PlayFirstSound()
    {
        if (!firstSoundPlayed)
        {
            audioSource.clip = firstSound;
            audioSource.Play();
            firstSoundPlayed = true;
        }
    }

    // Метод для програвання другого звуку
    public void PlaySecondSound()
    {
        if (firstSoundPlayed) // Переконайся, що перший звук програвся
        {
            audioSource.clip = secondSound;
            audioSource.Play();
        }
    }
}
