using UnityEngine;

public class DamageCaused : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 10;
    public int spawnPointIndex = 0; // Index of the spawn point to set when this enemy damages the player
    [SerializeField]
    private Collider2D damageCollider;

    void OnTriggerEnter2D(Collider2D damageCollider)
    {
        if (damageCollider.gameObject.CompareTag("Player"))
        {
            PlayerSpawn.Instance.SetSpawnPoint(spawnPointIndex); // Update spawn point first
            playerHealth.TakeDamage(damage);
            print("Damage");
        }
    }

}
