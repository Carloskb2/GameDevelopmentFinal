using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
    private bool platformDestroyed = false;
    private Vector3 originalPosition;
    public GameObject platform;
    public GameObject explosionEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Invoke("DestroyPlatform", 0.5f);

        }
    }

    private void DestroyPlatform()
    {
        
        Debug.Log("Destroying Platform");

        platformDestroyed = true;
        AudioManager.Instance.PlaySound(AudioManager.Instance.collapseSound);

        ExplodeEffect();
        gameObject.SetActive(false);


        Invoke("PlatformRestore", 1.0f);


    }

    private void PlatformRestore()
    {
        Debug.Log("Respawning Platform");

        if (platformDestroyed && platform != null)
        {
            gameObject.SetActive(true);

        }
    }

     private void ExplodeEffect()
    {
        // Instantiate the explosion prefab at the platform's position
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosion, 0.1f);

    }

}
