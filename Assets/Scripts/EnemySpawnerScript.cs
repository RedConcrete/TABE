using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnDelay = 5.0f; // Time delay between spawns
    public Vector3 spawnSize = new Vector3(10f, 1f, 10f);

    void Start()
    {
        StartCoroutine(SpawnPrefabsWithDelay());
    }

    System.Collections.IEnumerator SpawnPrefabsWithDelay()
    {
        while (true)
        {
            Vector3 randomPosition = GenerateRandomPosition();
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);

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
        float randomY = Random.Range(-spawnSize.y / 2f, spawnSize.y / 2f);
        float randomZ = Random.Range(-spawnSize.z / 2f, spawnSize.z / 2f);

        return new Vector3(randomX, randomY, randomZ) + transform.position;
    }
}