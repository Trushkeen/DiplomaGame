using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    void Update()
    {
        transform.position += transform.forward * -1F;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var objectHit = collision.gameObject;

    }
}
