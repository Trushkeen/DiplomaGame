using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MilitaryTankController : MonoBehaviour
{
    [Header("Rocket Prefabs")]
    public GameObject TankShell;
    public GameObject TankShellPoint;

    [Header("Sound Management")]
    public AudioSource TankShellAudioEmitter;
    public GameObject[] BulletPoints;
    public List<AudioSource> BulletPointsAudioEmitters;
    public AudioClip RocketSound;
    public AudioClip BulletSound;

    [Header("Delays")]
    public float ShotDelayRocket;
    public float ShotDelayBullet;

    [Header("Other")]
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
        TankShellAudioEmitter = GetComponent<AudioSource>();
        foreach (var i in BulletPoints)
        {
            BulletPointsAudioEmitters.Add(i.GetComponent<AudioSource>());
        }
        foreach (var i in BulletPointsAudioEmitters)
        {
            i.clip = BulletSound;
            i.volume = 0.1F;
        }
        StartCoroutine(ShootRocket());
        StartCoroutine(ShootBullet());
    }

    private void FixedUpdate()
    {
        MoveToTarget();
        CheckPlayerTargeted();
        RotateTowerTowardsPlayer();
        if (PlayerVisible)
        {
            TryToShootRocketInPlayer();
            TryToShootBullets();
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
        //there also an error: tank facing backwards because of wrong rotation in blender
        //when new model will be ready, replace targeting method with commented
        Tower.transform.LookAt(targetPos);
        //Tower.transform.rotation = Quaternion.RotateTowards(Tower.transform.rotation, Player.transform.rotation, 1F);
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

    private void TryToShootBullets()
    {
        if (AbleToShootBullets
            && Vector3.Distance(transform.position, Player.transform.position) >= 1)
        {
            var hit = CheckPlayerTargeted();
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                for (int i = 0; i < BulletPoints.Length; i++)
                {
                    BulletPointsAudioEmitters[i].Play();
                    //Debug.DrawRay(BulletPoints[i].transform.position, -BulletPoints[i].transform.forward * 300F, Color.red);
                    if (Physics.Raycast(BulletPoints[i].transform.position, -BulletPoints[i].transform.forward * 300F,
                        out RaycastHit bulletHit, 300F))
                    {
                        if (bulletHit.transform.gameObject.CompareTag("Player"))
                        {
                            bulletHit.transform.gameObject.GetComponent<PlayerStats>().HP -= 1F;
                        }
                    }
                }
                StartCoroutine(ShootBullet());
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
