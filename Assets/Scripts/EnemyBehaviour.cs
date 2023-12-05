using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private string playerTag = "Player"; // Set the player tag in the inspector
    public float moveSpeed = 5f; // Adjust the speed as needed

    private Transform player;

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
    }

    void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
