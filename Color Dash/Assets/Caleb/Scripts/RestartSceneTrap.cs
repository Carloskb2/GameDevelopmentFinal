using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneTrap : MonoBehaviour
{
    public PlayerHealth playerHealth;
    [SerializeField]
    private Collider2D damageCollider;
    [SerializeField]
    private string currentLevel;

    private int previousHealth;
    private bool shouldRestartScene;

    void OnEnable()
    {
        playerHealth.OnHealthChanged += HandleHealthChanged;
        previousHealth = playerHealth.health; // Initialize previousHealth
    }

    void OnDisable()
    {
        playerHealth.OnHealthChanged -= HandleHealthChanged;
    }

    private void HandleHealthChanged(int newHealth)
    {
        float healthPercentage = (float)newHealth / 100.0f;

        if (newHealth > previousHealth) // Check if health has decreased
        {
            shouldRestartScene = true;
        }

        previousHealth = newHealth; // Update previousHealth for next comparison
    }

    void OnTriggerEnter2D(Collider2D damageCollider)
    {
        if (shouldRestartScene && playerHealth.health == 100 && damageCollider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(currentLevel);
        }
    }
}
