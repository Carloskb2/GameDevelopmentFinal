using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Level Information")]
    public string currentLevel;
    public string nextLevel;

    [Header("Collectable Management")]
    public int collectablesNeeded = 5;
    [SerializeField]
    private int collectablesCollected = 0;
    [SerializeField]
    private GameObject portal;

    void Start()
    {
        if (portal != null) portal.SetActive(false);
        Collectable.OnCollected += CollectableCollected; // Subscribe to the event
    }

    void OnDestroy()
    {
        Collectable.OnCollected -= CollectableCollected; // Unsubscribe to prevent memory leaks
    }

    public void LoadNextLevel()
    {
        currentLevel = nextLevel;
        SceneManager.LoadScene(nextLevel);
    }

    private void CollectableCollected(CollectableID id)
    {
        collectablesCollected++;
        CheckCollectables();
    }

    void CheckCollectables()
    {
        if (collectablesCollected >= collectablesNeeded && portal != null)
        {
            portal.SetActive(true); // Activate the portal
        }
    }
}
