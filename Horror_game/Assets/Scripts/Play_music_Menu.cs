using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_music_Menu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip firstSound;
    public AudioClip secondSound;

    private bool firstSoundPlayed = false;

    public void PlayFirstSound()
    {
        audioSource.clip = firstSound;
        audioSource.Play();
    }

    public void PlaySecondSound()
    {
        audioSource.clip = secondSound;
        audioSource.Play();
        StartCoroutine(ClearAudioClipAfterPlay(secondSound.length));
    }

    private System.Collections.IEnumerator ClearAudioClipAfterPlay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.clip = null;
    }
}
