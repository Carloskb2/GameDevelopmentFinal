using UnityEngine;
using Cinemachine;
using System.Collections;

public class AutoTargetPlayer : MonoBehaviour
{
    public string playerTag = "PlayerAgent"; // Tag used to identify the player GameObject
    public float checkInterval = 1.0f; // Time interval to check for player's presence

    private CinemachineVirtualCamera virtualCamera;
    private GameObject currentPlayer;

    void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera == null)
        {
            Debug.LogError("CinemachineVirtualCamera component not found on the GameObject.");
            return;
        }

        PlayerHealth.OnPlayerDestroyed += HandlePlayerDestroyed; // Subscribe to the event
        StartCoroutine(CheckForPlayer());
    }

    void OnDestroy()
    {
        PlayerHealth.OnPlayerDestroyed -= HandlePlayerDestroyed; // Unsubscribe to prevent memory leaks
    }

    private void HandlePlayerDestroyed()
    {
        currentPlayer = null; // Reset the current player reference
    }

    IEnumerator CheckForPlayer()
    {
        yield return new WaitForSeconds(0.1f); // Wait a bit before the first search

        while (true)
        {
            if (currentPlayer == null || !currentPlayer.activeInHierarchy)
            {
                UpdateCameraTarget();
            }
            yield return new WaitForSeconds(checkInterval);
        }
    }

    void UpdateCameraTarget()
    {
        // Check if the current player target is null or not active
        currentPlayer = GameObject.FindGameObjectWithTag(playerTag);

        if (currentPlayer != null)
        {
            virtualCamera.Follow = currentPlayer.transform;
            virtualCamera.LookAt = currentPlayer.transform;
        }
        else
        {
            Debug.LogWarning("Player GameObject not found in the scene. Ensure your player is tagged correctly.");
        }
    }
}
