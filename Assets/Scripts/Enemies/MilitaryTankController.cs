using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MilitaryTankController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        var agent = GetComponent<NavMeshAgent>();
        var playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        agent.speed = GetComponent<Mob>().Speed;
        agent.SetDestination(playerPos);
    }
}
