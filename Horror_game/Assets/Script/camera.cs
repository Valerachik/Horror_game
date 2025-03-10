using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // Посилання на машину
    public Vector3 offset = new Vector3(0, 5, -10); // Відступ камери
    public float smoothSpeed = 5f; // Швидкість слідування

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 2); // Дивитися трохи вище об'єкта
    }
}
