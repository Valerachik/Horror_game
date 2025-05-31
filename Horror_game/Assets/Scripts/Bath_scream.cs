using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Device;

public class Bath_scream : MonoBehaviour
{
    public GameObject screamerObject;
    private Animator screamAnimator;

    private bool triggered = false;
    void Start()
    {
        if (screamerObject != null && !triggered)
        {
            screamAnimator = screamerObject.GetComponent<Animator>();
            screamerObject.SetActive(false);
        }
    }
    void OnMouseDown()
    {
        if (CompareTag("door_trig") && !triggered)
        {
            ShowScreamer();
        }
    }
    void ShowScreamer()
    {
        if (screamerObject != null)
        {
            screamerObject.SetActive(true);
            screamAnimator.Play("ScreamAnim", 0, 1f);
            triggered = true;
        }
     
        Destroy(gameObject);
    }
    public void OnScreamAnimationEnd()
    {
        if (screamerObject != null)
        {
            screamerObject.SetActive(false);
        }
       

    }
}
