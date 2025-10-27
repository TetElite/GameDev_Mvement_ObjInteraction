using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                   // Drag Fina here
    public Vector3 offset = new Vector3(0, 8, -12); // Behind & above player
    public float smoothSpeed = 10f;            // Higher = snappier follow

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position behind player
        Vector3 desiredPosition = target.position + offset;

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Look at player slightly above center
        Vector3 lookTarget = target.position + Vector3.up * 2.5f;
        transform.LookAt(lookTarget);
    }
}
