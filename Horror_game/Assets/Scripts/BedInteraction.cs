using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteraction : MonoBehaviour
{
    public static bool canSleep = false;
    private bool hasInteracted = false;

    private void OnMouseDown()
    {
        if (hasInteracted || !canSleep) return;
        hasInteracted = true;
        DialogueManager.Instance.ShowDialogue("Вже так пізно, розберуся з цим завтра.\nІ так багато сьогодні на мене навалилося");
        Invoke(nameof(GoToNextPhase), 3f); 
    }

    private void GoToNextPhase()
    {
        DialogueManager.Instance.HideDialogue();
        StoryManager.Instance.SetPhase(StoryPhase.WakeUp);
    }
}
