using UnityEngine;

public class ClimbingTutorialTrigger : MonoBehaviour
{
    [SerializeField]
    private GameTutorial gameTutorial; // Reference to the GameTutorial script
    [SerializeField]
    private GameObject climbingColliderGO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameTutorial.StartClimbingTutorial();
            climbingColliderGO.SetActive(false);
        }
    }
}