using UnityEngine;

public class AnimateObject : MonoBehaviour
{
    public GameObject explosionEffect;
    AudioManager audioManager;  

    private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            ExplodeEffect();
        }
    }

     private void ExplodeEffect()
    {
        audioManager.PlaySound(audioManager.finalSound);

        Debug.Log("Effect");
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosion, 1.0f);

    }

}
