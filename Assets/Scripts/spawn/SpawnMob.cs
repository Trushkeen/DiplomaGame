using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMob : MonoBehaviour
{
    Vector3 SpawnVector;
    public int MaxSpawn;
    public float Delay;
    private bool AbleToSpawn = true;

    public GameObject[] DefaultEnemies;
    public GameObject[] Minibosses;


    private void Start()
    {
        SpawnVector = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        if (AbleToSpawn && GameObject.FindGameObjectsWithTag("Enemy").Length <= SpawnersController.MaxEnemies)
        {
            for (int i = 0; i < 5; i++)
            {
                var enemy = Instantiate(original: DefaultEnemies[Random.Range(0, DefaultEnemies.Length)],
                    position: SpawnVector, rotation: transform.rotation);
            }
            var boss = Instantiate(original: Minibosses[Random.Range(0, Minibosses.Length)],
                    position: SpawnVector, rotation: transform.rotation);
            boss.transform.localScale *= 3;
            var bossStats = boss.GetComponent<Mob>();
            bossStats.HP *= 4;
            bossStats.MaxHP = bossStats.HP;
            StartCoroutine(SpawnCooldown());
        }
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnCooldown());
    }

    private IEnumerator SpawnCooldown()
    {
        AbleToSpawn = false;
        yield return new WaitForSeconds(Delay);
        AbleToSpawn = true;
    }
}
