using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MilitaryTankController : MonoBehaviour
{
    public GameObject TankShell;
    public GameObject TankShellPoint;

    public GameObject Tower;

    private NavMeshAgent NavAgent;
    private GameObject Player;

    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        Player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        MoveToTarget();
        Vector3 targetPos = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        Tower.transform.LookAt(targetPos);
    }

    public void MoveToTarget()
    {
        var playerPos = Player.transform.position;
        NavAgent.speed = GetComponent<Mob>().Speed;
        NavAgent.SetDestination(playerPos);
    }
}
