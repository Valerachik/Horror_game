using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject camera;               
    public float distance = 5f;            
    public GameObject currentItem;   // зробимо публічним, щоб ChestInteraction мав доступ
    bool canPickUp;
    bool isHolding;

    public static bool isHoldingKey = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PickUp();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Drop();
        }
    }

    void PickUp()
{
    RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Item")
            {
                if (canPickUp) Drop();

                currentItem = hit.transform.gameObject;
                Rigidbody rb = currentItem.GetComponent<Rigidbody>();
                if (rb != null) rb.isKinematic = true;

                Collider col = currentItem.GetComponent<Collider>();
                if (col != null) col.enabled = false;
                currentItem.transform.parent = transform;
                currentItem.transform.localPosition = Vector3.zero;
                currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                canPickUp = true;
                isHolding = true;
                isHoldingKey = currentItem.name.ToLower().Contains("key");
            }
            if (hit.transform.tag == "Note")
            {
                if (canPickUp) Drop();

                currentItem = hit.transform.gameObject;
                Rigidbody rb = currentItem.GetComponent<Rigidbody>();
                if (rb != null) rb.isKinematic = true;

                Collider col = currentItem.GetComponent<Collider>();
                if (col != null) col.enabled = false;

                currentItem.transform.parent = transform;

                currentItem.transform.localPosition = new Vector3(-0.612f, 0.125f, -0.494f);
                currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                currentItem.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
   

                canPickUp = true;
                isHolding = true;
                isHoldingKey = currentItem.name.ToLower().Contains("key");
            }

        }
}

   void Drop()
{
    currentItem.transform.parent = null;
    Rigidbody rb = currentItem.GetComponent<Rigidbody>();
    if (rb != null) rb.isKinematic = false;

    Collider col = currentItem.GetComponent<Collider>();
    if (col != null) col.enabled = true;
    canPickUp = false;
    isHolding = false;
    currentItem = null;
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
