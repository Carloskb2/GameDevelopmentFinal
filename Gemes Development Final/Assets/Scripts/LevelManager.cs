using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    [Header("Level name")]
    public string currentLevel;
    public string nextLevel;

    public void LoadNextLevel()
    {
        currentLevel = nextLevel; // Update current level to the next one
        SceneManager.LoadScene(nextLevel); // Load the next level
    }
}
