using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth ScriptableObject
    public Image healthBarImage; // Reference to the health bar Image
    public AudioSource hitSound; // Assign this in the Inspector
    public Camera virtualCamera; // Assign CM Vcam1 


    [Header("Camera Shake:")]
    [SerializeField]
    float duration;
    [SerializeField]
    float magnitude;


    private int previousHealth;

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
        healthBarImage.fillAmount = healthPercentage;

        if (newHealth < previousHealth) // Check if health has decreased
        {
            print("Hit");
            hitSound.Play(); // Play hit/scream sound
            StartCoroutine(ShakeCamera()); // Trigger camera shake
        }

        previousHealth = newHealth; // Update previousHealth for next comparison
    }

    IEnumerator ShakeCamera()
    {
        // camera shake logic
        print("shaking Camera");
        Vector3 originalPos = virtualCamera.transform.position;
        //duration = 0.2f; // Duration of the shake
        //magnitude = 0.9f; // Magnitude of the shake

        for (float elapsed = 0; elapsed < duration; elapsed += Time.deltaTime)
        {
            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            virtualCamera.transform.position = new Vector3(x, y, originalPos.z);

            yield return null;
        }

        virtualCamera.transform.position = originalPos; // Reset camera position
    }


}
