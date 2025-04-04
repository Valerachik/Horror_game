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

            audioSource.clip = firstSound;
            audioSource.Play();
    }

    // Метод для програвання другого звуку
    public void PlaySecondSound()
    {
            audioSource.clip = secondSound;
            audioSource.Play();
        StartCoroutine(ClearAudioClipAfterPlay(secondSound.length));
    }
    // Метод для скидання audioSource.clip після програвання
    private System.Collections.IEnumerator ClearAudioClipAfterPlay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.clip = null;
    }
}
