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
            // Check if AudioManager instance is available
            if (AudioManager.Instance != null)
            {
                // Play the Get Hit Sound
                AudioManager.Instance.PlaySound(AudioManager.Instance.getHitSound);
                AudioManager.Instance.PlaySound(AudioManager.Instance.painSound);
            }
            playerHealth.TakeDamage(damage);
            print("Damage");
        }
    }

    private void BloodEffect(Vector3 playerPosition)
    {
        Debug.Log("BloodBurst");
        GameObject blood = Instantiate(bloodEffect, new Vector3(playerPosition.x, playerPosition.y, playerPosition.z - 10), Quaternion.identity);
        Destroy(blood, 1.0f);
    }
}
