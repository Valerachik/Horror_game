using UnityEngine;
using Mirror;

public class MouseLook : NetworkBehaviour
{
    public float mouseSensitivity = 100f; // Чутливість миші
    public Transform playerBody; // Посилання на об'єкт персонажа

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Приховуємо курсор і фіксуємо його в центрі екрану
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        // Зчитуємо рух мишки
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Обмежуємо поворот камери по осі X (щоб не переверталася)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Повертаємо камеру вверх-вниз
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Повертаємо персонажа ліво-право
        playerBody.Rotate(Vector3.up * mouseX);
    }
}