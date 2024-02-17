using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgCaused : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 10;
    [SerializeField]
    private Collider2D damageCollider;

    void OnTriggerEnter2D(Collider2D damageCollider)
    {
        if (damageCollider.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
            print("Damage");
        }
    }
}
