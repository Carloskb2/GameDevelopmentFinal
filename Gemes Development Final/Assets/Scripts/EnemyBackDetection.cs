using UnityEngine;

public class EnemyBackDetection : MonoBehaviour
{
    [SerializeField]
    private EnemyPatrol enemyPatrol; // Reference to the EnemyPatrol script
    [SerializeField]
    private Collider2D backCollider;
    private void OnTriggerEnter2D(Collider2D backCollider)
    {
        if (backCollider.gameObject.CompareTag("Player"))
        {
            print("Back");
            enemyPatrol.TurnAround();
        }
    }
}
