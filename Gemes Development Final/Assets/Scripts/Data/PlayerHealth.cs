using UnityEngine;

[CreateAssetMenu(fileName = "New Player Health", menuName = "Player/Health")]
public class PlayerHealth : ScriptableObject
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        health = 100; // Reset health

        // Call SpawnPlayer from PlayerSpawn
        if (PlayerSpawn.Instance != null)
        {
            PlayerSpawn.Instance.SpawnPlayer();
        }
        else
        {
            Debug.LogError("PlayerSpawn instance not found.");
        }

        // Additional respawn logic here
    }
}