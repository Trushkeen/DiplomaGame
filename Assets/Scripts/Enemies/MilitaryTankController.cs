using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MilitaryTankController : MonoBehaviour
{
    public GameObject TankShell;
    public GameObject TankShellPoint;
    public float ShotDelayRocket;
    public float ShotDelayBullet;

    public GameObject Tower;

    private NavMeshAgent NavAgent;
    private GameObject Player;
    private bool AbleToShootRocket;
    private bool AbleToShootBullets;
    private bool PlayerVisible = false;

    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        Player = FindObjectOfType<PlayerMovement>().gameObject;
        StartCoroutine(ShootRocket());
    }

    private void FixedUpdate()
    {
        MoveToTarget();
        CheckPlayerTargeted();
        RotateTowerTowardsPlayer();
        if (PlayerVisible)
        {
            TryToShootRocketInPlayer();
        }

    }

    private RaycastHit CheckPlayerTargeted()
    {
        //ATTENTION! Minus value because of model wrong facing. Fix when normal model will be available.
        if (Physics.Raycast(TankShellPoint.transform.position, -TankShellPoint.transform.forward * 200F,
            out RaycastHit hit, 200F))
        {
            PlayerVisible = true;
        }
        else
        {
            PlayerVisible = false;
        }
        return hit;
    }

    void Update()
    {
    }

    public void MoveToTarget()
    {
        var playerPos = Player.transform.position;
        NavAgent.speed = GetComponent<Mob>().Speed;
        NavAgent.SetDestination(playerPos);
    }

    //TODO: should be remade to face nearest player (calculate distance)
    void RotateTowerTowardsPlayer()
    {
        Vector3 targetPos = new Vector3(Player.transform.position.x, transform.position.y - 1, Player.transform.position.z);
        Tower.transform.LookAt(targetPos);
    }

    void TryToShootRocketInPlayer()
    {
        if (AbleToShootRocket
            && Vector3.Distance(transform.position, Player.transform.position) >= 1)
        {
            var hit = CheckPlayerTargeted();
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                var obj = Instantiate(TankShell);
                obj.transform.position = TankShellPoint.transform.position;
                obj.transform.rotation = TankShellPoint.transform.rotation;
                StartCoroutine(ShootRocket());
            }
        }
    }

    IEnumerator ShootRocket()
    {
        AbleToShootRocket = false;
        yield return new WaitForSeconds(ShotDelayRocket);
        AbleToShootRocket = true;
    }

    IEnumerator ShootBullet()
    {
        AbleToShootBullets = false;
        yield return new WaitForSeconds(ShotDelayBullet);
        AbleToShootBullets = true;
    }
}
