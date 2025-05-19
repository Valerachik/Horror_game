using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance; 
    public GameObject DialogPanel;
    public TextMeshProUGUI DialogText;

    void Awake()
    {
        Instance = this;
        HideDialogue();
    }

    public void ShowDialogue(string text)
    {
        DialogPanel.SetActive(true);
        DialogText.text = text;
    }

    public void HideDialogue()
    {
        DialogPanel.SetActive(false);
    }
}
