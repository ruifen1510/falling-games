using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public Wave[] waves;

    private Wave currWave;
    private int currWaveNum;

    private bool canSpawn = true;

    private float nextSpawnTime;

    private void Update()
    {
        currWave = waves[currWaveNum];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0 && !canSpawn && currWaveNum+1 != waves.Length)
        {
            currWaveNum++;
            canSpawn = true;
        }
    }

   [SerializeField] private float spawnRadius = 6f;

    void SpawnWave()
    {
        if(canSpawn && nextSpawnTime < Time.time)
        {
            GameObject enemy = currWave.enemyPrefab[Random.Range(0, currWave.enemyPrefab.Length)];

            Vector2 spawnPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(enemy, spawnPos, Quaternion.identity);
            currWave.noOfEnemies--;
            nextSpawnTime = Time.time + currWave.spawnInterval;
            if(currWave.noOfEnemies == 0)
            {
                canSpawn = false;
            }

        }
    }
}

[System.Serializable]
public class Wave
{
    public string waveName;
    public int noOfEnemies;
    public GameObject[] enemyPrefab;
    public float spawnInterval;
}
