using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMob : MonoBehaviour
{
    Vector3 SpawnVector;
    public int MaxSpawn;
    public float Delay;
    private bool AbleToSpawn = true;

    public GameObject[] Enemies;

    private void Start()
    {
        SpawnVector = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        if (AbleToSpawn && GameObject.FindGameObjectsWithTag("Enemy").Length <= MaxSpawn)
        {
            var obj = Instantiate(original: Enemies[0], position: SpawnVector, rotation: transform.rotation);
        }
        StartCoroutine(SpawnCooldown());
    }

    private IEnumerator SpawnCooldown()
    {
        AbleToSpawn = false;
        yield return new WaitForSeconds(Delay);
        AbleToSpawn = true;
    }
}
