using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateList : MonoBehaviour
{
    [Header("Об'єкт, який треба активувати")]
    public GameObject objectToActivate;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;

        triggered = true;

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Не призначено objectToActivate у TriggerObjectActivator.");
        }
    }
}
