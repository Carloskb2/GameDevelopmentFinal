using UnityEngine;

public class DamageCaused : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 10;
    public int spawnPointIndex = 0; // Index of the spawn point to set when this enemy damages the player

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerSpawn.Instance.SetSpawnPoint(spawnPointIndex); // Update spawn point first
            playerHealth.TakeDamage(damage);
        }
    }

}
