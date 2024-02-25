﻿using UnityEngine;

public class AnimateObject : MonoBehaviour
{
    public GameObject explosionEffect;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            ExplodeEffect();
        }
    }

     private void ExplodeEffect()
    {
        Debug.Log("BloodBurst");
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(explosion, 1.0f);

    }

}