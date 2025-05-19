using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilogueTrigger1 : MonoBehaviour
{
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            DialogueManager.Instance.ShowDialogue("Epilogue");
            Invoke(nameof(GoToNextPhase), 2f);
        }
    }
    private void GoToNextPhase()
    {
        DialogueManager.Instance.HideDialogue();
        StoryManager.Instance.SetPhase(StoryPhase.Intro);
    }
}
