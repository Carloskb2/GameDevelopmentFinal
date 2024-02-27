using UnityEngine;
using UnityEngine.SceneManagement;


public class GameWinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(AudioManager.Instance.winSound);
            SceneManager.LoadScene("GameWin");

        }
    }
}
