using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI; // SerializeField allows us to keep it private but still set it in the Unity Editor.
    
    private bool isGamePaused = false; // Tracks the pause state of the game.

    // Update is called once per frame
    void Update()
    {
        // Check for the Escape key press to toggle the pause state.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Pauses the game.
    private void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu.
        Time.timeScale = 0f; // Pause the game by setting time scale to 0.
        isGamePaused = true; // Update the pause state.
    }

    // Resumes the game.
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu.
        Time.timeScale = 1f; // Unpause the game by setting time scale to 1.
        isGamePaused = false; // Update the pause state.
    }

    // Placeholder for options menu functionality.
    public void OpenOptions()
    {
        Debug.Log("Open options menu here."); // Placeholder for actual implementation.
    }

    // Loads the main menu scene.
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game's time scale is reset before loading the main menu.
        SceneManager.LoadScene("Starting Menu"); // Load the main menu scene.
    }

    // Quits the game.
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // It's helpful to log this action when testing in the editor.
        Application.Quit(); // Quit the application.
    }
}
