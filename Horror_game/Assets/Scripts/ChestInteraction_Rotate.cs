using System.Collections;
using UnityEngine;

public class ChestInteraction_Rotate : MonoBehaviour
{
    public GameObject chestCover;           
    public float openAngle = -90f;            
    public float interactDistance = 5f;       
    public Camera playerCamera;               
    private bool isOpened = false;            

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isOpened)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactDistance))
            {

                if (hit.collider.gameObject.name == "Old Chest")
                {
                    if (PickUpItem.isHoldingKey)
                    {
                        isOpened = true;
                        chestCover.transform.Rotate(openAngle, 0f, 0f); 
                        Debug.Log("✅ Шкатулка відкрита!");
                 
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