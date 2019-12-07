using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankController : MonoBehaviour, IMobActions
{
    private Mob Stats;

    public void Attack(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            obj.GetComponent<PlayerStats>().DiscardHP(20F);
            obj.GetComponent<Rigidbody>().AddForce(transform.up * 300F + transform.forward * 300F, ForceMode.Acceleration);
        }
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
