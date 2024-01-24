using UnityEngine;

public class DamageCaused : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("taking damage" + playerHealth.health);
            playerHealth.TakeDamage(damage);
        }
    }
}
