using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScript : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.PlaySound(AudioManager.Instance.winSound);
    }

    // Loads the main menu scene
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game's time scale is reset before loading the main menu
        SceneManager.LoadScene("Start Menu"); // Load the main menu scene
    }

    // Quits the game
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Quit the application
    }
}
