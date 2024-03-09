﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinScript : MonoBehaviour
{
    void Start()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySound(AudioManager.Instance.winSound);
    }

    // Loads the main menu scene
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game's time scale is reset before loading the main menu
        SceneManager.LoadScene("Start Menu"); // Load the main menu scene
    }
}