using UnityEngine;

public class SlenderAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 5f;
    public float rotationSpeed = 2f;
    public float detectionRange = 10f;
    public float teleportCooldown = 10f;
    public float teleportRange = 20f;
    public float teleportDistance = 5f;

    private bool isChasing = false;
    private bool isTeleporting = false;
    private float teleportTimer = 0f;

    private void Update()
    {
        // Calculate the distance between the AI and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within the detection range, start chasing
        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // If the AI is chasing, rotate towards the player and move towards them
        if (isChasing)
        {
            RotateTowardsPlayer();

            // Move towards the player
            transform.Translate(Vector3.forward * chaseSpeed * Time.deltaTime);

            // Check if teleportation is ready
            if (!isTeleporting && Time.time >= teleportTimer)
            {
                // Calculate the teleportation position in front of the player
                Vector3 teleportDirection = (player.position - transform.position).normalized;
                Vector3 teleportPosition = player.position + teleportDirection * teleportDistance;

                // Limit teleportation to within the specified range
                float clampedDistance = Mathf.Clamp(Vector3.Distance(teleportPosition, player.position), 0f, teleportRange);
                teleportPosition = player.position + teleportDirection * clampedDistance;

                // Teleport the AI to the new position
                transform.position = teleportPosition;

                // Start the teleportation cooldown
                isTeleporting = true;
                teleportTimer = Time.time + teleportCooldown;
            }
        }
        else
        {
            isTeleporting = false;
        }
    }

    private void RotateTowardsPlayer()
    {
        // Get the direction to the player
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f; // Prevent rotation in the Y-axis

        // Calculate the rotation towards the player
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Smoothly rotate towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
