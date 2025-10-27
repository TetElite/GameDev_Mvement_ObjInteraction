using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float speed = 7f; // Movement speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Move player
        Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
