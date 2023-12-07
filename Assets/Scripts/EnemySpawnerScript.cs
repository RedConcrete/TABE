using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnDelay = 5.0f; // Time delay between spawns
    public bool TestAmount = true;
    public Vector3 spawnSize = new Vector3(10f, 1f, 10f);
    private bool spawnEnemys = true;
    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        StartCoroutine(SpawnPrefabsWithDelay());
    }

    System.Collections.IEnumerator SpawnPrefabsWithDelay()
    {
        while (spawnEnemys)
        {
            Vector3 randomPosition = GenerateRandomPosition();

            // Set the Y component to be a fixed value
            randomPosition.y = transform.position.y;

            // Check if the position is clear before spawning
            if (!IsPositionOccupied(randomPosition, prefabToSpawn.GetComponent<Collider>().bounds.size))
            {   if (!TestAmount)
                {
                    Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
                    spawnedPositions.Add(randomPosition);
                }
                else
                {   
                    Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
                    spawnedPositions.Add(randomPosition);
                    spawnEnemys = false;
                }
                
            }

            // Wait for the specified delay before the next spawn
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnSize);
    }

    Vector3 GenerateRandomPosition()
    {
        float randomX = Random.Range(-spawnSize.x / 2f, spawnSize.x / 2f);
        float randomZ = Random.Range(-spawnSize.z / 2f, spawnSize.z / 2f);

        return new Vector3(randomX, transform.position.y, randomZ) + transform.position;
    }

    bool IsPositionOccupied(Vector3 position, Vector3 prefabSize)
    {
        // Check if the position is in the list of spawned positions
        foreach (Vector3 spawnedPosition in spawnedPositions)
        {
            // Check if the distance between positions is greater than the sum of their sizes
            if (Vector3.Distance(position, spawnedPosition) < Mathf.Max(prefabSize.x, prefabSize.y, prefabSize.z))
            {
                return true; // Position is occupied
            }
        }
        return false; // Position is not occupied
    }
}
