using System.Collections;
using UnityEngine;

public class ChestInteraction_Rotate : MonoBehaviour
{
    public GameObject chestCover;             // об'єкт кришки шкатулки
    public float openAngle = -90f;            // кут, на який відкриватиметься кришка
    public float interactDistance = 5f;       // дистанція до шкатулки
    public Camera playerCamera;               // камера гравця
    private bool isOpened = false;            // щоб не відкривалась повторно

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isOpened)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactDistance))
            {
                // Заміна "old chest" на "Old Chest" (чутливо до регістру)
                if (hit.collider.gameObject.name == "Old Chest")
                {
                    if (PickUpItem.isHoldingKey)
                    {
                        isOpened = true;
                        chestCover.transform.Rotate(openAngle, 0f, 0f); // відкриваємо кришку
                        Debug.Log("✅ Шкатулка відкрита!");
                        // тут можна додати скрімер або записку
                    }
                    else
                    {
                        Debug.Log("🚫 Потрібен ключ.");
                    }
                }
            }
        }
    }
}