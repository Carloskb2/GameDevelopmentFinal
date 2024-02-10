using UnityEngine;

public class EnterPortalTutorialTrigger : MonoBehaviour
{
    [SerializeField]
    private GameTutorial1 gameTutorial; // Reference to the GameTutorial script
    [SerializeField]
    private GameObject enterPortalColliderGO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameTutorial.EnterPortalGemTutorial();
            enterPortalColliderGO.SetActive(false);
        }
    }
}