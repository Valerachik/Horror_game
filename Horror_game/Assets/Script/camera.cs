using UnityEngine;

public class сamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10); 
    public float speed = 5f;
    private float rotation = 0f;
    

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 2); 
    }
}
