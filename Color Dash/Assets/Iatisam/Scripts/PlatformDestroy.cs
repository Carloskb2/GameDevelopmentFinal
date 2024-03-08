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

        if (!platformDestroyed)
        {
            gameObject.SetActive(false);

            ExplodeEffect();
            AudioManager.Instance.PlaySound(AudioManager.Instance.collapseSound);

            Invoke("PlatformRestore", 1.0f);

            platformDestroyed = true;
        }
    }

    private void PlatformRestore()
    {
        Debug.Log("Respawning Platform");

        if (platformDestroyed && platform != null)
        {
            gameObject.SetActive(true);
            platformDestroyed = false;
        }
    }

     private void ExplodeEffect()
    {
        // Instantiate the explosion prefab at the platform's position
        GameObject explosion = Instantiate(explosionEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity);
        Destroy(explosion, 0.1f);
    }

}
