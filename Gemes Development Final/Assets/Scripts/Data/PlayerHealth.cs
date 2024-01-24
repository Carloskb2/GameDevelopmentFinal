using UnityEngine;


[CreateAssetMenu(fileName = "New Player Health", menuName = "Player/Health")]

public class PlayerHealth : ScriptableObject
{
    public int health = 100;

    public delegate void PlayerDestroyedAction();
    public static event PlayerDestroyedAction OnPlayerDestroyed;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnPlayerDestroyed?.Invoke(); // Notify that the player is about to be destroyed
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