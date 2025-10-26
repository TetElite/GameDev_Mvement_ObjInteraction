using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;              // Player object to follow
    public Vector3 offset = new Vector3(0, 10, -10); // Camera position relative to player
    public float smoothSpeed = 0.125f;    // How smooth the camera moves

    void LateUpdate()
    {
        if (target == null) return;

        // Desired camera position based on player + offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move camera toward the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        // Make the camera always look at the player
        transform.LookAt(target);
    }
}
