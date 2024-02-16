using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TriggerNewSpawnPoint : MonoBehaviour
{
    [SerializeField] int spawnPointIndex;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerSpawn.Instance.SetSpawnPoint(spawnPointIndex);
        }
    }
}
