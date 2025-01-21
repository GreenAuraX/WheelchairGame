using UnityEngine;

public class MoveCharacterRigidbody : MonoBehaviour
{
    // Fields and Properties
    public Transform[] targets; // Points the NPC should move between
    public float speed = 5f;
    public float reachThreshold = 0.1f; // How close the NPC needs to be to switch to the next target
    private Rigidbody rb;
    private int currentTargetIndex = 0;

    // Unity Event Methods
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (targets.Length == 0)
        {
            Debug.LogError("No targets assigned. Please assign target points in the inspector.");
        }

        // Optional: Freeze rotation to ensure the character stays upright
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        if (targets.Length == 0)
            return;

        // Get the current target position
        Transform currentTarget = targets[currentTargetIndex];

        // Calculate direction to the target
        Vector3 direction = (currentTarget.position - transform.position).normalized;

        // Ensure the direction's Y component is ignored for rotation
        direction.y = 0;

        // Rotate the NPC to face the target
        if (direction != Vector3.zero) // Avoid rotating to (0,0,0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * speed);
        }

        // Move the NPC towards the target
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        // Check if the NPC is close enough to the target
        float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);
        if (distanceToTarget <= reachThreshold)
        {
            // Switch to the next target
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
        }
    }
}