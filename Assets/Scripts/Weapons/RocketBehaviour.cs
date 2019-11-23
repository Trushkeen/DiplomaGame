using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 3F);
    }

    void Update()
    {
        transform.position += transform.forward * -1F;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var objectHit = collision.gameObject;
        if (objectHit.CompareTag("Player"))
        {
            var stats = objectHit.GetComponent<PlayerStats>();
            stats.HP -= 60;
        }
    }
}
