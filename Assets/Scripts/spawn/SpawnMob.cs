using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMob : MonoBehaviour
{
    GameObject obj;
    Vector3 SpawnVector;
    public int maxSpawn = 5;
    private bool AbleToSpawn = true;
    private void Start()
    {
        obj = GameObject.FindGameObjectWithTag("Enemy");
        SpawnVector = new Vector3(transform.position.x, 26F, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (AbleToSpawn && GameObject.FindGameObjectsWithTag("Enemy").Length <= maxSpawn)
        {
            var obje = Instantiate(obj, SpawnVector,transform.rotation).transform.parent = null;
            obje.GetComponent<NavMeshAgent>().Warp(gameObject.transform.position);

            StartCoroutine(SpawnCooldown());
        }

    }

    private IEnumerator SpawnCooldown()
    {
        AbleToSpawn = false;
        yield return new WaitForSeconds(15.0F);
        AbleToSpawn = true;

    }
}
