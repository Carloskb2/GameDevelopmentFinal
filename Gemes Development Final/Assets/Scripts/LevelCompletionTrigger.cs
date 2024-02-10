using UnityEngine;

public class LevelCompletionTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<LevelManager>().LoadNextLevel();
        }
    }
}
