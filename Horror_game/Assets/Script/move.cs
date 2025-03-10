using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private bool isMoving; // Флаг для руху

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody не знайдено! Додай компонент Rigidbody до об'єкта.");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime); // 🚀 Рух вперед відносно повороту

        if (Input.GetKey(KeyCode.A))
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * -100f * Time.fixedDeltaTime)); // 🔄 Обертання вліво

        if (Input.GetKey(KeyCode.D))
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * 100f * Time.fixedDeltaTime)); // 🔄 Обертання вправо

        if (Input.GetKey(KeyCode.S))
            rb.MovePosition(rb.position - transform.forward * speed * Time.fixedDeltaTime); // 🔙 Рух назад відносно об'єкта
    }

}