using UnityEngine;
using Mirror;

public class CameraFollow : NetworkBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float speed = 5f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Увімкнути камеру тільки для локального гравця
        if (!isLocalPlayer && cam != null)
        {
            cam.enabled = false;
        }
    }

    void LateUpdate()
    {
        if (!isLocalPlayer || target == null) return;

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 2);
    }
}