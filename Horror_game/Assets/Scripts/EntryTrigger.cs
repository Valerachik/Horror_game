using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryTrigger : MonoBehaviour
{
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            DialogueManager.Instance.ShowDialogue("*Огляньте Вітальню*");
            Invoke(nameof(GoToNextPhase), 10f);
        }
    }
    private void GoToNextPhase()
    {
        DialogueManager.Instance.HideDialogue();
        StoryManager.Instance.SetPhase(StoryPhase.LookingAroundLivingRoom);
    }
}
