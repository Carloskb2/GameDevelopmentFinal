﻿using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableID collectableID; // Reference to the shared ID

    public delegate void CollectedAction(CollectableID id);
    public static event CollectedAction OnCollected;
    public GameObject animationEffect_1;
    public GameObject animationEffect_2;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (animationEffect_1 != null && animationEffect_2 != null)
            {
                AnimateObject(other.gameObject.transform.position);
            }
            OnCollected?.Invoke(collectableID); // Pass the ID when collected
            gameObject.SetActive(false); // Hide or destroy the collectable
            
        }
    }

    private void AnimateObject(Vector3 playerPosition)
    {
        Debug.Log("AnimationWorks");
        GameObject animEffect_1 = Instantiate(animationEffect_1, playerPosition, Quaternion.identity);
        GameObject animEffect_2 = Instantiate(animationEffect_2, playerPosition, Quaternion.identity);
        Destroy(animEffect_1, 1.0f);
        Destroy(animEffect_2, 1.0f);
    }
}


