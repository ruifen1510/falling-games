using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner enemySpawner;
    public static bool isBossDead = false;

    [SerializeField] private Wave[] waves;
    [SerializeField] private int currWaveNum;
    [SerializeField] private float spawnRadius = 6f;
    [SerializeField] private float timeToSpawnEnemy = 5f;

    private Wave currWave;
    private bool canSpawn = true;
    private float nextSpawnTime;

    void Update()
    {
        currWave = waves[currWaveNum];
        Invoke("SpawnWave", timeToSpawnEnemy);

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0 && !canSpawn && currWaveNum+1 != waves.Length)
        {
            currWaveNum++;
            canSpawn = true;
        }

        if (totalEnemies.Length == 0 && !canSpawn && currWaveNum+1 == waves.Length)
        {
            isBossDead = true;
        }
    }

    void SpawnWave()
    {
        if(canSpawn && nextSpawnTime < Time.time)
        {
            GameObject enemy = currWave.typeofEnemies[Random.Range(0, currWave.typeofEnemies.Length)];

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
    public GameObject[] typeofEnemies;
    public float spawnInterval;
}
