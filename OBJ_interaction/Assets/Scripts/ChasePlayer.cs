using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform target;        
    public float speed = 4f;        
    public float stopDistance = 0.5f; 

    void Update()
    {
        if (target == null) return;

        // Direction only on XZ plane (ignore Y)
        Vector3 direction = (target.position - transform.position);
        direction.y = 0;                       // ignore vertical difference
        direction.Normalize();

        // Move enemy
        transform.position += direction * speed * Time.deltaTime;

        // Lock Y to terrain/player height
        Vector3 pos = transform.position;
        pos.y = target.position.y;             // or terrain.SampleHeight(transform.position) + offset
        transform.position = pos;

        // Look at Fina (only horizontal)
        Vector3 lookTarget = target.position;
        lookTarget.y = transform.position.y;   // same Y as enemy
        transform.LookAt(lookTarget);

        // Game Over check
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= stopDistance)
        {
            Debug.Log("Game Over!");
        }
    }
}
