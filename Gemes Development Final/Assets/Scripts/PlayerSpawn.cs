using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    Transform spawnPoint;
    public static PlayerSpawn Instance { get; private set; }

    private GameObject currentPlayerInstance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            SpawnPlayer(); // Instantiate the player when the game starts
        }
    }

    public void SpawnPlayer()
    {
        if (currentPlayerInstance != null)
        {
            Destroy(currentPlayerInstance);
        }

        if (playerPrefab != null && spawnPoint != null)
        {
            currentPlayerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
