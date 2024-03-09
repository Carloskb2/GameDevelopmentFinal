using UnityEngine;

public class EnemyHeadHit : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyGO;
    [SerializeField]
    private GameObject deathEffectPrefab; // Particle effect prefab for enemy death
    [SerializeField]
    private Collider2D headCollider;
    [SerializeField]
    private float bounceForce = 10f; // Adjust the force magnitude as needed

    private void Awake()
    {
        deathEffectPrefab.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D headCollider)
    {
        if (headCollider.gameObject.CompareTag("Player"))
        {
            deathEffectPrefab.SetActive(true);

            // Apply a bounce force to the player
            Rigidbody2D playerRb = headCollider.gameObject.GetComponentInParent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Apply an immediate upward force
                playerRb.AddForce(new Vector2(0, bounceForce), ForceMode2D.Impulse);
            }

            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySound(AudioManager.Instance.enemyDieSound); // Play the enemy death sound

        // Instantiate the death effect
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity);
        }

        // Destroy the enemy GameObject
        Destroy(enemyGO);
    }
}
