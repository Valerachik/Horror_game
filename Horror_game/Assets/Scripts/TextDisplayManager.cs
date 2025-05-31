using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayManager : MonoBehaviour
{
    public static TextDisplayManager Instance { get; private set; }


    [SerializeField] private Text uiText;

    private HashSet<string> displayedTexts = new HashSet<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ShowUniqueText(string textId, string message)
    {
        if (displayedTexts.Contains(textId))
        {
            Debug.Log("Text " + textId + " was already shown.");
            return;
        }

        displayedTexts.Add(textId);

        if (uiText != null)
        {
            StartCoroutine(DisplayTextCoroutine(message));
        }
        else
        {
            Debug.LogWarning("UI Text component is missing in TextDisplayManager.");
        }
    }

    private IEnumerator DisplayTextCoroutine(string message)
    {
        uiText.text = message;
        uiText.gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        uiText.gameObject.SetActive(false);
    }
}

