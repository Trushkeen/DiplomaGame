using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAttackHand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().DiscardHP(GetComponentInParent<Mob>().Damage);
        }
    }
}
