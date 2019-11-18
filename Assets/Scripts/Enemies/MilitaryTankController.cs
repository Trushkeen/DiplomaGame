using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MilitaryTankController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
