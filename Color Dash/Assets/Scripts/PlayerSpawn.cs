using UnityEngine;
using System.Collections.Generic; // Needed for lists

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public List<Transform> spawnPoints; // List of spawn points
    public static PlayerSpawn Instance { get; private set; }

    private GameObject currentPlayerInstance;
    private int currentSpawnPointIndex = 0; // Index of the current spawn point

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            SpawnPlayer(); // Instantiate the player at the start
        }
    }

    // Call this method to update the current spawn point
    public void SetSpawnPoint(int spawnPointIndex)
    {
        if (spawnPointIndex >= 0 && spawnPointIndex < spawnPoints.Count)
        {
            currentSpawnPointIndex = spawnPointIndex;
            Debug.Log("Setting spawn point index to: " + spawnPointIndex);
        }
        else
        {
            Debug.LogError("Invalid spawn point index.");
        }
    }

    public void SpawnPlayer()
    {
        if (currentPlayerInstance != null)
        {
            Destroy(currentPlayerInstance);
        }

        if (playerPrefab != null && spawnPoints.Count > 0)
        {
            Transform spawnPoint = spawnPoints[currentSpawnPointIndex];
            currentPlayerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Spawning player at index: " + currentSpawnPointIndex);
        }
    }


}
