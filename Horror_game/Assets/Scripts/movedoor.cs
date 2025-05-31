using UnityEngine;

public class movedoor : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 2f;
    private bool isOpen = false;
    private Quaternion startRotation;
    private Quaternion openRotation;

    public GameObject screamObject;
    private Animator screamAnimator;
    private bool scremer = false;

    public string doorId; 

    void Start()
    {
        startRotation = transform.localRotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * startRotation;

        if (screamObject != null)
        {
            screamObject.SetActive(false);
            screamAnimator = screamObject.GetComponent<Animator>();
        }
    }

    void OnMouseDown()
    {
    
        if (!SceneManager3D.Instance.IsDoorUnlocked(doorId))
        {
            TextDisplayManager.Instance.ShowUniqueText("Locked_" + doorId, "Двері зачинені.");
            return;
        }

        isOpen = !isOpen;

        if (CompareTag("door_trig") && !scremer)
        {
            ShowScreamer();
        }
    }

    void Update()
    {
        if (isOpen)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, openRotation, Time.deltaTime * speed);
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, startRotation, Time.deltaTime * speed);
        }
    }

    void ShowScreamer()
    {
        if (screamObject != null)
        {
            screamObject.SetActive(true);
            screamAnimator.Play("ScreamAnim", 0, 1f);
            scremer = true;
        }
    }

    public void OnScreamAnimationEnd()
    {
        if (screamObject != null)
        {
            screamObject.SetActive(false);
        }
    }
}
