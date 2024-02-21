using UnityEngine;

public class UnlockNextLevel : MonoBehaviour
{
    public int currentLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        int nextLevel = currentLevel + 1;

        int highestLevelReached = PlayerPrefs.GetInt("HighestLevelReached", 1);

        if (nextLevel > highestLevelReached)
        {
            PlayerPrefs.SetInt("HighestLevelReached", nextLevel);
        }
    }
}
