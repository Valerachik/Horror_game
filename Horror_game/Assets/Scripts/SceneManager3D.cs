using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GamePhase
{
   // Epilog,
    Intro,
    Sleep,
    WakeUp,
    SearchingNoteKitchen,
    SearchingNoteBathroom,
    SearchingNoteBedroom,
    SearchingNoteStoreroom,
    TheEnd
}

public class SceneManager3D : MonoBehaviour
{
    public static SceneManager3D Instance { get; set; }

    public GamePhase CurrentPhase { get; set; } = GamePhase.Intro;

    private HashSet<string> completedActions = new HashSet<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool AdvancePhase(GamePhase newPhase)
    {
        if (CurrentPhase == newPhase)
        {
            Debug.Log("Phase " + newPhase + " already active.");
            return false;
        }

        if (completedActions.Contains(newPhase.ToString()))
        {
            Debug.Log("Phase " + newPhase + " already completed.");
            return false; // phase already done
        }

        CurrentPhase = newPhase;
        completedActions.Add(newPhase.ToString());

        Debug.Log("Advanced to phase: " + newPhase);

        if (TextDisplayManager.Instance != null)
        {
            string taskKey = "PhaseTask_" + newPhase.ToString();
            TextDisplayManager.Instance.ShowUniqueText(taskKey, GetPhaseTaskText(newPhase));
        }

        return true;
    }

    public bool IsActionDone(string actionId)
    {
        return completedActions.Contains(actionId);
    }

    public void MarkActionDone(string actionId)
    {
        if (!completedActions.Contains(actionId))
        {
            completedActions.Add(actionId);
            Debug.Log("Action marked done: " + actionId);
        }
    }
    public bool IsDoorUnlocked(string doorId)
    {
        switch (doorId)
        {
            case "Fridge":
                return CurrentPhase >= GamePhase.Intro;
            case "BD":
                return CurrentPhase >= GamePhase.SearchingNoteBathroom;
            case "TD":
                return CurrentPhase >= GamePhase.SearchingNoteBedroom;
            case "BeD":
                return CurrentPhase >= GamePhase.SearchingNoteBedroom;
            case "SD":
                return CurrentPhase >= GamePhase.SearchingNoteStoreroom;
            default:
                return false; 
        }
    }

    private string GetPhaseTaskText(GamePhase phase)
    {

        if (CurrentPhase == GamePhase.TheEnd)
        {
            CurrentPhase = GamePhase.Intro;
        }
        switch (phase)
        {
            case GamePhase.Intro:
                return "";
            case GamePhase.Sleep:
                return "��� ��� ����, ��������� � ��� ������. � ��� ������ ������� �� ���� ����������";
            case GamePhase.WakeUp:
                return "";
            case GamePhase.SearchingNoteKitchen:
                return "������ �� ������� ��������� ������ �������";
            case GamePhase.SearchingNoteBathroom:
                return "";
            case GamePhase.SearchingNoteBedroom:
                return "³���������� �� ������ ���";
            case GamePhase.SearchingNoteStoreroom:
                return "";
            case GamePhase.TheEnd:
                return "\"�� ���������\"";
            default:
                return "";
        }

    }
}