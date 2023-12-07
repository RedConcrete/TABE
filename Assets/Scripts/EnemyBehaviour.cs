using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private string playerTag = "Player"; // Set the player tag in the inspector
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float repulsionDistance = 2f; // Adjust the repulsion distance as needed
    public float repulsionForce = 10f; // Adjust the repulsion force as needed

    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        // Find the player object using the specified tag
        GameObject playerObject = GameObject.FindWithTag(playerTag);

        // Ensure the player object is found
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player has the specified tag.");
        }

        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
            RepelOtherEnemies();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // Use Rigidbody's velocity to move the object
        rb.velocity = direction * moveSpeed;

    }

    void RepelOtherEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            if (enemy != gameObject) // Exclude self
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < repulsionDistance)
                {
                    Vector3 repulsionDirection = transform.position - enemy.transform.position;
                    repulsionDirection.Normalize();

                    // Apply repulsion force
                    rb.AddForce(repulsionDirection * repulsionForce, ForceMode.Acceleration);
                }
            }
        }
    }
}
