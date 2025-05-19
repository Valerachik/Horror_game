using UnityEngine;
using Mirror;

public class move : NetworkBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private bool isMoving;
    
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
        if (!isLocalPlayer) return;
        if (Input.GetKey(KeyCode.W))
            rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.A))
            rb.MovePosition(rb.position - transform.right * speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.D))
            rb.MovePosition(rb.position + transform.right * speed * Time.fixedDeltaTime); 

        if (Input.GetKey(KeyCode.S))
            rb.MovePosition(rb.position - transform.forward * speed * Time.fixedDeltaTime); 
    }
    

}