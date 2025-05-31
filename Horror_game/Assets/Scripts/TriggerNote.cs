using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNote : MonoBehaviour
{

    public GamePhase nextPhase;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player")) return;

        triggered = true; 
        SceneManager3D.Instance.AdvancePhase(nextPhase);
    }
}
