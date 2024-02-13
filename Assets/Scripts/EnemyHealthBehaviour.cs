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
            
        }

        Debug.Log("HP: " + currentHealth.ToString());
    }

    // Diese Methode wird aufgerufen, wenn das Projektil den Gegner trifft
    void OnTriggerEnter(Collider other)
    {
        /*
        if (other.CompareTag("Projectile"))
        {
            Projectile projectile = other.GetComponent<Projectile>();
            if (projectile != null)
            {
                // Den Schaden des Projektils nehmen
                TakeDamage(projectile.damage);

                // Zerstöre das Projektil, nachdem es den Gegner getroffen hat
                Destroy(other.gameObject);
            }
        }
        */
    }


}
