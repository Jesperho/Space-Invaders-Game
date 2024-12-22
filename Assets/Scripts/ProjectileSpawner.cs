
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject EnemyProjectile;
    public float spawnTimer;
    public float spawnMax = 10;
    public float spawnMin = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
        Instantiate(EnemyProjectile, transform.position, Quaternion.identity);
        spawnTimer = Random.Range(spawnMin, spawnMax);
        }
    }
}
