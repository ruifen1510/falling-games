using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject explosionPrefab;
    public GameObject player;

    public GameObject[] bomb;
    public float timeToSpawnBomb = 3f;
    public float spawnRadius = 7f;

    void Start()
    {
        StartCoroutine(BombSpawner());
    }

    void Update()
    {
        PlayerDead();
    }

    void PlayerDead()
    {
        if (HealthBar.health <= 0)
        {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = player.transform.position;
            Destroy(player, 2f);

            SceneManager.LoadScene(4);
        }
    }

    IEnumerator BombSpawner()
    {
        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        yield return new WaitForSeconds(timeToSpawnBomb);
        Instantiate(bomb[Random.Range(0, bomb.Length)], spawnPos, Quaternion.identity);
    }
}
