using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderBehaviour : MonoBehaviour
{
    public Animator Animator;
    public Mob Mob;

    private NavMeshAgent NavAgent;
    private GameObject Player;
    private bool Jumping = false;
    private bool FollowPlayer = true;
    private Rigidbody Rigidbody;

    void Start()
    {
        Animator = GetComponent<Animator>();
        Player = FindObjectOfType<PlayerMovement>().gameObject;
        NavAgent = GetComponent<NavMeshAgent>();
        Rigidbody = GetComponent<Rigidbody>();
        if (Mob == null)
        {
            Mob = GetComponent<Mob>();
        }
        NavAgent.speed = Mob.Speed;
    }

    void Update()
    {
        if (FollowPlayer)
        {
            MoveToTarget();
        }
        if (!Jumping)
        {
            CheckAbilityToJump();
        }
    }

    //Attack
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var go = collision.gameObject;
            go.GetComponent<PlayerStats>().DiscardHP(Mob.Damage);
        }
    }

    private void MoveToTarget()
    {
        NavAgent.SetDestination(Player.transform.position);
    }

    private void Runaway()
    {
        var randomPos = new Vector3(Random.Range(0, 100000), Random.Range(0, 100000), Random.Range(0, 100000));
        //var runawayPos = Player.transform.position * Random.Range(1000, 5000);
        NavAgent.SetDestination(randomPos);
    }

    private void CheckAbilityToJump()
    {
        if (NavAgent.remainingDistance < 65F && !Jumping)
        {
            Animator.Play("JumpPrepare");
            Jumping = true;
            StartCoroutine(Jump());
        }
        else if (Jumping)
        {
            Animator.SetBool("WalkingTransition", true);
        }
    }

    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.4F);
        Rigidbody.AddForce(transform.forward * 30000F, ForceMode.Force);
        FollowPlayer = false;
        Runaway();
        Animator.SetBool("WalkingTransition", true);
        yield return new WaitForSeconds(3F);
        FollowPlayer = true;
        yield return new WaitForSeconds(Random.Range(3.5F, 6F));
        Jumping = false;
    }
}
