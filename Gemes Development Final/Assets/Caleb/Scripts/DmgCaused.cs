using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DmgCaused : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 10;
    [SerializeField]
    private Collider2D damageCollider;
    public GameObject bloodEffect;

    void OnTriggerEnter2D(Collider2D damageCollider)
    {
        if (damageCollider.gameObject.CompareTag("Player"))
        {
            if (bloodEffect != null)
            {
                BloodEffect(damageCollider.gameObject.transform.position);
            }
            playerHealth.TakeDamage(damage);
            print("Damage");
        }
    }

    private void BloodEffect(Vector3 playerPosition)
    {
        Debug.Log("BloodBurst");
        GameObject blood = Instantiate(bloodEffect, playerPosition, Quaternion.identity);
        Destroy(blood, 1.0f);
    }
}
