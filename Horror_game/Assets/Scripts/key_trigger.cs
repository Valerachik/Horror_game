using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_trigger : MonoBehaviour
{
    [Header("Унікальний ID повідомлення (будь-який унікальний текст)")]
    public string messageId;

    [Header("Повідомлення, яке буде показано")]
    [TextArea] public string message;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;

        triggered = true;
        TextDisplayManager.Instance.ShowUniqueText(messageId, message);
    }
}
