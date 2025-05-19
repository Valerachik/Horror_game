using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Scream : MonoBehaviour
{
    public GameObject _scream;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("scream_trigger") && other.CompareTag("Player"))
        {
            _scream.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
