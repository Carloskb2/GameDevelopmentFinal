using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableID collectableID; // Reference to the shared ID

    public delegate void CollectedAction(CollectableID id);
    public static event CollectedAction OnCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollected?.Invoke(collectableID); // Pass the ID when collected
            gameObject.SetActive(false); // Hide or destroy the collectable
        }
    }
}

