using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Load the game scene
    }

    public void OpenOptions()
    {
        // Implemention of code to open the options/settings menu 
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }
}
