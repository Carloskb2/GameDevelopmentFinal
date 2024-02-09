using UnityEngine;

public class GetGemTutorialTrigger : MonoBehaviour
{
    [SerializeField]
    private GameTutorial1 gameTutorial; // Reference to the GameTutorial script
    [SerializeField]
    private GameObject getGemColliderGO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameTutorial.StartGetGemTutorial();
            getGemColliderGO.SetActive(false);
        }
    }
}