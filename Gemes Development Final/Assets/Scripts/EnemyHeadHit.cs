using UnityEngine;

public class EnemyHeadHit : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyGO;
    [SerializeField]
    private GameObject deathEffectPrefab; // Particle effect prefab for enemy death
    [SerializeField]
    private Collider2D headCollider;
    private void OnTriggerEnter2D(Collider2D headCollider)
    {
        if (headCollider.gameObject.CompareTag("Player"))
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        // Play the enemy death sound
        AudioManager.Instance.PlaySound(AudioManager.Instance.enemyDieSound);

        // Instantiate the death effect
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // Destroy the enemy GameObject
        Destroy(enemyGO);
    }
}
