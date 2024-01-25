using UnityEngine;

public class Collectable : MonoBehaviour
{
    public delegate void CollectedAction();
    public static event CollectedAction OnCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnCollected?.Invoke(); // Trigger the event
            gameObject.SetActive(false); // Optionally hide or destroy the collectable
        }
    }
}
