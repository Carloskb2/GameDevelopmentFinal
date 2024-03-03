using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1"); // Load the game scene level 1
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("Level Selection Menu"); // Load the level selection scene
    }
}
