using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnersController : MonoBehaviour
{
    public static int MaxEnemies = 15;

    GameObject[] PlayerArray;
    GameObject[] SpawnersArray;
    public float MaxRange = 500F;
    public float MinRange = 100F;

    private void Start()
    {
        SpawnersArray = GameObject.FindGameObjectsWithTag("SpawnMob");

    }
    private void FixedUpdate()
    {
        PlayerArray = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        foreach (var itemSpawn in SpawnersArray)
        {
            foreach (var itemPlayer in PlayerArray)
            {
                float distance = Vector3.Distance(itemSpawn.transform.position, itemPlayer.transform.position);
                if (distance < MaxRange && distance > MinRange)
                {
                    itemSpawn.SetActive(true);
                }
                else
                {
                    itemSpawn.SetActive(false);
                }
            }
        }
    }
}
