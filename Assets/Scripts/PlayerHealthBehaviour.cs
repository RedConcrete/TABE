using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private Text healthText; // Reference to the UI Text object

    void Start()
    {
        currentHealth = maxHealth;
        FindHealthText();
        UpdateHealthUI();
    }

    void FindHealthText()
    {
        // Find the UI Text component with the tag "PlayerUI"
        GameObject uiObject = GameObject.FindGameObjectWithTag("PlayerUI");

        if (uiObject != null)
        {
            healthText = uiObject.GetComponent<Text>();

            if (healthText == null)
            {
                Debug.LogError("The GameObject with tag 'PlayerUI' does not have a Text component.");
            }
        }
        else
        {
            Debug.LogError("No GameObject with tag 'PlayerUI' found in the scene.");
        }
    }

    // Method to reduce player's health
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Make sure health doesn't go below 0
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateHealthUI();

        // Check if player is dead
        if (currentHealth == 0)
        {
            // You can add game over logic or respawn logic here
        }
    }

    // Method to update the UI Text with current health
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth.ToString();
        }
    }
}
