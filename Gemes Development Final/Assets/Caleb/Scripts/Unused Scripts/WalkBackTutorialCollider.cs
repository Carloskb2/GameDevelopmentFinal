using UnityEngine;

public class WalkBackTutorialCollider : MonoBehaviour
{
    [SerializeField]
    private GameTutorial1 gameTutorial; // Reference to the GameTutorial script

    private bool hasAlreadyHit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!hasAlreadyHit && other.gameObject.CompareTag("PlayerAgent"))
        {
            gameTutorial.StartWalkBackTutorial();
            hasAlreadyHit = true;
        }
    }
}