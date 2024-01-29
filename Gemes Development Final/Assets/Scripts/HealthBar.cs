using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth ScriptableObject
    public Image healthBarImage; // Reference to the health bar Image

    void Update()
    {
        // Update health bar based on player's health
        float healthPercentage = (float)playerHealth.health / 100.0f;
        healthBarImage.fillAmount = healthPercentage;
    }
}
