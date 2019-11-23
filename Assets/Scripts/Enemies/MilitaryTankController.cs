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
    private bool AbleToShootRocket;

    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        Player = FindObjectOfType<PlayerMovement>().gameObject;
        StartCoroutine(ShootRocket());
    }

    void Update()
    {
        MoveToTarget();
        Vector3 targetPos = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        Tower.transform.LookAt(targetPos);
        if (AbleToShootRocket)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) >= 20)
            {
                var obj = Instantiate(TankShell);
                obj.transform.position = TankShellPoint.transform.position;
                obj.transform.rotation = TankShellPoint.transform.rotation;
                StartCoroutine(ShootRocket());
            }
        }
    }

    public void MoveToTarget()
    {
        var playerPos = Player.transform.position;
        NavAgent.speed = GetComponent<Mob>().Speed;
        NavAgent.SetDestination(playerPos);
    }

    IEnumerator ShootRocket()
    {
        AbleToShootRocket = false;
        yield return new WaitForSeconds(1F);
        AbleToShootRocket = true;
    }
}
