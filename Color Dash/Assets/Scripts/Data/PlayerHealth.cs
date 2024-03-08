using UnityEngine;


[CreateAssetMenu(fileName = "New Player Health", menuName = "Player/Health")]

public class PlayerHealth : ScriptableObject
{
    public int health = 100;

    public delegate void PlayerDestroyedAction();
    public static event PlayerDestroyedAction OnPlayerDestroyed;

    public delegate void HealthChangedAction(int newHealth);
    public event HealthChangedAction OnHealthChanged;

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0); // Ensure health doesn't go below 0
        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            OnPlayerDestroyed?.Invoke(); // Notify that the player is about to be destroyed
            Respawn();
        }
    }

    public void Respawn()
    {
        health = 100; // Reset health
        OnHealthChanged?.Invoke(health); // Invoke the event to update the UI

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