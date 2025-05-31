using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manager to display unique text or tasks in the game UI.
/// Displays each text only once.
/// Attach this to an active GameObject in your scene with a Text UI element assigned.
/// </summary>
public class TextDisplayManager : MonoBehaviour
{
    public static TextDisplayManager Instance { get; private set; }

    // Unity UI Text component where messages will be shown
    [SerializeField] private Text uiText;

    // Keeps track of keys for messages already displayed
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

    /// <summary>
    /// Display text with unique id (only once)
    /// </summary>
    /// <param name="textId">Unique id for this text</param>
    /// <param name="message">Text to show</param>
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

    /// <summary>
    /// Coroutine to display the message for a limited time.
    /// You can customize duration or implement fade effects here.
    /// </summary>
    private IEnumerator DisplayTextCoroutine(string message)
    {
        uiText.text = message;
        uiText.gameObject.SetActive(true);

        // Show for 5 seconds (customize as needed)
        yield return new WaitForSeconds(5f);

        uiText.gameObject.SetActive(false);
    }
}

