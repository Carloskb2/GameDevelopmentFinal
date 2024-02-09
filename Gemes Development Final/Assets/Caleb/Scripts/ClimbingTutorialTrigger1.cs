using UnityEngine;

public class ClimbingTutorialTrigger1 : MonoBehaviour
{
    [SerializeField]
    private GameTutorial1 gameTutorial; // Reference to the GameTutorial script
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