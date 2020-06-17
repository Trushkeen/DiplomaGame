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
        //ATTENTION! Minus value because of model wrong facing. Fix when normal model will be available.
        transform.position += transform.forward * -6F;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var objectHit = collision.gameObject;
        if (objectHit.CompareTag("Player"))
        {
            var stats = objectHit.GetComponent<PlayerStats>();
            stats.DiscardHP(60);
        }
    }
}
