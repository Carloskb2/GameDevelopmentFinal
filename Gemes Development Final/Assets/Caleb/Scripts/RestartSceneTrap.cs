using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneTrap : MonoBehaviour
{
    public PlayerHealth playerHealth;
    [SerializeField]
    private Collider2D damageCollider;
    [SerializeField]
    private string currentLevel;

    void OnTriggerEnter2D(Collider2D damageCollider)
    {
        if (playerHealth.health == 100 && damageCollider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(currentLevel);
        }
    }
}
