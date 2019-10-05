using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankController : MonoBehaviour, IMobActions
{
    private Mob Stats;

    public void Attack(GameObject obj)
    {
        obj.GetComponent<PlayerStats>().HP -= 20;
        obj.GetComponent<Rigidbody>().AddForce(transform.up * 500F + transform.forward * 500F, ForceMode.Acceleration);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void MoveToTarget()
    {
        var agent = GetComponent<NavMeshAgent>();
        var playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        agent.speed = GetComponent<Mob>().Speed;
        agent.SetDestination(playerPos);
    }
    
    void Start()
    {
        Stats = GetComponent<Mob>();
    }
    
    void Update()
    {
        MoveToTarget();
        if (Stats.HP < 0) Death();
    }
}
