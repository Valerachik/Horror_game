using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomTrigger : MonoBehaviour
{
    private bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            DialogueManager.Instance.ShowDialogue("Вже так пізно, розберуся з цим завтра. \r\nІ так багато сьогодні на мене навалилося\r\n");
            Invoke(nameof(GoToNextPhase), 3f);
        }
    }
    private void GoToNextPhase()
    {
        DialogueManager.Instance.HideDialogue();
        StoryManager.Instance.SetPhase(StoryPhase.Sleep);
    }
}
