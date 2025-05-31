using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public string keyId;
    public string message;

    private bool picked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (picked || !other.CompareTag("Player")) return;

        picked = true;
        TextDisplayManager.Instance.ShowUniqueText(keyId, message);
        Destroy(gameObject);
    }
}
