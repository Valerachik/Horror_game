using UnityEngine;
using Mirror;

public class move : NetworkBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private bool isMoving;
    public Vector3 crouch = new Vector3(0.8f, 0.5f, 0.8f);
    public float crouchpos = -0.5f;
    private Vector3 OriginalScale;
    private Vector3 OriginalPosition;
    private bool isCrouching = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        OriginalScale = transform.localScale;
        OriginalPosition = transform.position;

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

        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = true;
            transform.localScale = crouch;
            transform.position = new Vector3(transform.position.x, transform.position.y + crouchpos, transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            isCrouching = false;
            transform.localScale = OriginalScale;
            transform.position = new Vector3(transform.position.x, OriginalPosition.y, transform.position.z);
        }
    }


}