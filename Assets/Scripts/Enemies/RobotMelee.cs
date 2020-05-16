using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotMelee : MonoBehaviour
{
    //AttackType:
    //OneHanded - 0, BladeFury - 1
    public Animator Animator;
    public Mob Mob;

    private NavMeshAgent NavAgent;
    private GameObject Player;

    void Start()
    {
        Animator = GetComponent<Animator>();
        Player = FindObjectOfType<PlayerMovement>().gameObject;
        NavAgent = GetComponent<NavMeshAgent>();
        if (Mob == null)
        {
            Mob = GetComponent<Mob>();
        }
        NavAgent.speed = Mob.Speed;
    }

    void Update()
    {
        NavAgent.SetDestination(Player.transform.position);

        if (NavAgent.remainingDistance < 30F)
        {
            Animator.SetBool("NearPlayer", true);
        }
        else
        {
            Animator.SetBool("NearPlayer", false);
        }

        if (Animator.GetBool("NearPlayer"))
        {
            Animator.SetInteger("AttackType", Random.Range(0, 2));
        }
    }
}
