using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingBehaviour : MonoBehaviour
{
    public Transform projectilePrefab; // Assign your projectile prefab in the Unity editor
    public float shootingDistance = 10f; // Set the specific shooting distance
    public float shootingInterval = 1f; // Set the time interval between shots
    public float projectileForce = 10f; // Set the force applied to the projectile

    void Start()
    {
        // Start shooting automatically using InvokeRepeating
        InvokeRepeating("ShootAtNearestEnemy", 0f, shootingInterval);
    }

    void ShootAtNearestEnemy()
    {
        // Find all objects with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // If there are no enemies, return
        if (enemies.Length == 0)
        {
            return;
        }

        Transform nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        // Iterate through each enemy and find the nearest one
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            // Check if the enemy is within the shooting distance
            if (distanceToEnemy <= shootingDistance && distanceToEnemy < nearestDistance)
            {
                nearestEnemy = enemy.transform;
                nearestDistance = distanceToEnemy;
            }
        }

        // If a nearest enemy is found, shoot a projectile towards it
        if (nearestEnemy != null)
        {
            // Instantiate the projectile at the player's position and make it look at the nearest enemy
            Transform projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Calculate the direction towards the nearest enemy
            Vector3 direction = (nearestEnemy.position - transform.position).normalized;

            // Apply force to the projectile in the calculated direction
            projectile.GetComponent<Rigidbody>().AddForce(direction * projectileForce, ForceMode.Impulse);
        }
    }
}
