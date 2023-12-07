using UnityEngine;

public class EnemyHealthBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("HP: " + currentHealth.ToString());
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Make sure health doesn't go below 0
        currentHealth = Mathf.Max(currentHealth, 0);

        // Check if enemy is dead
        if (currentHealth == 0)
        {
            // You can add game over logic or respawn logic here
        }

        Debug.Log("HP: " + currentHealth.ToString());
    }
}
