using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<TankController>().Attack(other.gameObject);
    }
}
