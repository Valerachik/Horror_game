using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_scream : MonoBehaviour
{
    public GameObject Scream;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("screamer") && other.CompareTag("Player"))
        {
            Scream.SetActive(true);
        }
    }
}
