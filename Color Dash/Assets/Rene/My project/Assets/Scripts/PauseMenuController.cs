using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI; // SerializeField allows us to keep it private but still set it in the Unity Editor.

    private bool isGamePaused = false; // Tracks the pause state of the game.

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the pause menu is not visible when the game starts
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for the Escape key press to toggle the pause state
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

    // Pauses the game
    private void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        isGamePaused = true; // Update the pause state
    }

    // Resumes the game
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Unpause the game by setting time scale to 1
        isGamePaused = false; // Update the pause state
    }

    // Restarts the current game scene
    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure the game's time scale is reset before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    // Loads the main menu scene
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game's time scale is reset before loading the main menu
        SceneManager.LoadScene("Start Menu"); // Load the main menu scene
    }
}
