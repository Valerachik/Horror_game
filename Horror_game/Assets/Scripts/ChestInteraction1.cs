using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject chestCover;
    public float interactDistance = 3f;
    public Camera playerCamera;

    public PickUpItem pickUpItem;  // посилання на скрипт PickUpItem, треба прив'язати в інспекторі

    private bool isOpened = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isOpened)
        {
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactDistance, Color.green, 2f);

            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactDistance))
            {
                Debug.Log($"🎯 Raycast влучив у: {hit.collider.gameObject.name}");

                if (hit.collider.gameObject.name == "Old Chest")
                {
                    Debug.Log($"🗝️ Стан ключа: PickUpItem.isHoldingKey = {PickUpItem.isHoldingKey}");

                    if (PickUpItem.isHoldingKey)
                    {
                        isOpened = true;

                        chestCover.transform.Rotate(-90f, 0f, 0f);

                        Debug.Log("✅ Шкатулка відкрита!");

                        if (pickUpItem != null)
                        {
                            pickUpItem.DestroyHeldKey();  // видаляємо ключ
                        }
                    }
                    else
                    {
                        Debug.Log("🚫 Потрібен ключ.");
                    }
                }
                else
                {
                    Debug.Log("❌ Це не шкатулка.");
                }
            }
            else
            {
                Debug.Log("🔴 Raycast не влучив ні в що.");
            }
        }
    }
}
