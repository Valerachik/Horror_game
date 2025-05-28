using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject camera;               
    public float distance = 15f;            
    public GameObject currentItem;   // зробимо публічним, щоб ChestInteraction мав доступ
    bool canPickUp;
    bool isHolding;

    public static bool isHoldingKey = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isHolding) Drop();
            else PickUp();
        }
    }

    void PickUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            Debug.Log($"🎯 Влучено у: {hit.transform.name}");

            if (hit.transform.CompareTag("Item"))
            {
                if (canPickUp) Drop();

                currentItem = hit.transform.gameObject;

                Rigidbody rb = currentItem.GetComponent<Rigidbody>();
                if (rb != null) rb.isKinematic = true;

                Collider col = currentItem.GetComponent<Collider>();
                if (col != null) col.enabled = false;

                currentItem.transform.parent = transform;
                currentItem.transform.localPosition = new Vector3(0, -1f, 1f);
                currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

                canPickUp = true;
                isHolding = true;

                isHoldingKey = currentItem.name.ToLower().Contains("key");
                Debug.Log($"🗝️ Підібрано предмет: {currentItem.name}, isHoldingKey = {isHoldingKey}");
            }
            else
            {
                Debug.Log("❌ Об'єкт не має тега 'Item'");
            }
        }
        else
        {
            Debug.Log("🔴 Raycast не влучив у предмет.");
        }
    }

    void Drop()
    {
        if (currentItem != null)
        {
            if (currentItem.name.ToLower().Contains("key"))
            {
                Debug.Log("🗝️ Ключ не можна скинути автоматично");
                return;
            }

            Debug.Log("🔻 Скидаємо предмет: " + currentItem.name);

            currentItem.transform.parent = null;

            Rigidbody rb = currentItem.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false;

            Collider col = currentItem.GetComponent<Collider>();
            if (col != null) col.enabled = true;

            canPickUp = false;
            isHolding = false;
            currentItem = null;
        }
    }

    // Ось метод, який буде викликатися з іншого скрипта для знищення ключа
    public void DestroyHeldKey()
    {
        if (currentItem != null && currentItem.name.ToLower().Contains("key"))
        {
            Destroy(currentItem);
            currentItem = null;
            isHoldingKey = false;
            canPickUp = false;
            isHolding = false;
            Debug.Log("🗝️ Ключ видалено після відкриття шкатулки");
        }
    }
}
