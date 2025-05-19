using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StoryPhase
{
    Epilogue,
    Intro,          
    LookingAroundLivingRoom,
    Sleep,          
    WakeUp,         
    NoteSearchLivingRoom,    
    NoteSearchKitchen,
    NoteSearchBathRoom,
    NoteSearchBedRoom,
    NoteSearchToiletRoom,
    NoteSearchStoreRoom,
    TheEnd
}
public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private StoryPhase currentPhase;

    public void SetPhase(StoryPhase phase)
    {
        currentPhase = phase;

        switch (phase)
        {
            case StoryPhase.Epilogue:

                break;
            case StoryPhase.Intro:
                DialogueManager.Instance.ShowDialogue("Пупупу… Будинок гірше ніж я думав…");
                Invoke(nameof(DialogueManager.Instance.HideDialogue), 3f);
                break;
            case StoryPhase.LookingAroundLivingRoom:
               
                break;
            case StoryPhase.Sleep:
                BedInteraction.canSleep = true; 
                break;
            case StoryPhase.WakeUp:

                break;
            case StoryPhase.NoteSearchLivingRoom:

                break;
            case StoryPhase.NoteSearchKitchen:

                break;
            case StoryPhase.NoteSearchBathRoom:

                break;
            case StoryPhase.NoteSearchBedRoom:

                break;
            case StoryPhase.NoteSearchToiletRoom:

                break;
            case StoryPhase.NoteSearchStoreRoom:

                break;
            case StoryPhase.TheEnd:

                break;
        }
    }
}
