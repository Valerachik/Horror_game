using UnityEngine;

public class movedoor : MonoBehaviour
{
    public float openAngle = 90f; // Кут відкривання
    public float speed = 2f; // Швидкість відкривання
    private bool isOpen = false;
    private Quaternion startRotation;
    private Quaternion openRotation;

    void Start()
    {
        startRotation = transform.localRotation;
        openRotation = Quaternion.Euler(0, openAngle, 0) * startRotation;
    }

    void OnMouseDown()
    {
        isOpen = !isOpen; // Перемикаємо стан дверей
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
}
