using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject currentItem;
    bool canPickUp;
    bool isHolding;
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
            if (hit.transform.tag == "Item")
            {
                if (canPickUp) Drop();

                currentItem = hit.transform.gameObject;
                currentItem.GetComponent<Rigidbody>().isKinematic = true;
                currentItem.transform.parent = transform;
                currentItem.transform.localPosition = Vector3.zero;
                currentItem.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                canPickUp = true;
                isHolding = true;
            }
        }
    }

    void Drop()
    {
        currentItem.transform.parent = null;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        canPickUp = false;
        currentItem = null;
        isHolding = false;
    }
}
