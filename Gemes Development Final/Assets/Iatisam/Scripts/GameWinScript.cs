using UnityEngine;
using UnityEngine.SceneManagement;


public class GameWinScript : MonoBehaviour
{
    AudioManager audioManager;

    private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySound(audioManager.winSound);
            SceneManager.LoadScene("GameWin");

        }
    }
}
