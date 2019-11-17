using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InSpawn : MonoBehaviour
{
    GameObject[] PlayerArray;
    GameObject[] SpawnMobArray;
    public float MaxRange = 500F;
    public float MinRange = 100F;

    private void Start()
    {
        SpawnMobArray = GameObject.FindGameObjectsWithTag("SpawnMob");

    }
    private void FixedUpdate()
    {
        PlayerArray = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
    

        foreach (var itemSpawn in SpawnMobArray)
        {
            foreach (var itemPlayer in PlayerArray)
            {
                float distance = Vector3.Distance(itemSpawn.transform.position, itemPlayer.transform.position);
                if (distance < MaxRange && distance > MinRange)
                {
                    print(distance);
                    itemSpawn.SetActive(true);
                }
                else
                {
                    print(distance);
                    itemSpawn.SetActive(false);
                }
            }
        }
    }
}
