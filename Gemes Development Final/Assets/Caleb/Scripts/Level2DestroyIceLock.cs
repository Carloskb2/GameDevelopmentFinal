using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2DestroyIceLock : MonoBehaviour
{
    [SerializeField] GameObject iceBridgeRight;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            iceBridgeRight.SetActive(false);    
        }
    }
}
