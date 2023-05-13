using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Reference to the zombie prefab to be spawned
    public float spawnRate = 2f; // Rate at which zombies will spawn (in seconds)
    public float spawnRadius = 10f; // Radius around the spawner within which zombies will be spawned
    public GameObject player;
    public NavMeshAgent zombie;

    private float lastSpawnTime = -Mathf.Infinity; // Time at which the last zombie was spawned

    void Update()
    {

        if (Time.time > lastSpawnTime + spawnRate)
        {
            // Spawn a new zombie
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPosition.y = 0; // Ensure that the zombie is spawned on the ground
            Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            lastSpawnTime = Time.time;
        }
    }
}
