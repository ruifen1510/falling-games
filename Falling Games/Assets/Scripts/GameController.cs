using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject playerExplosion;
    public GameObject player;

    //public GameObject[] bomb;
    //public float timeToSpawnBomb = 3f;
    //public float spawnRadius = 7f;

    void Start()
    {
        //StartCoroutine(BombSpawner());
        playerExplosion.SetActive(false);
    }

    void Update()
    {
        StartCoroutine(PlayerDead());
    }

    IEnumerator PlayerDead()
    {
        if (HealthBar.health <= 0)
        {
            playerExplosion.SetActive(true);

            yield return new WaitForSeconds(0.8f);

            Destroy(player);

            yield return new WaitForSeconds(1.5f);

            SceneManager.LoadScene("GameOver");
        }
    }

    /*IEnumerator BombSpawner()
    {
        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        yield return new WaitForSeconds(timeToSpawnBomb);
        Instantiate(bomb[Random.Range(0, bomb.Length)], spawnPos, Quaternion.identity);
    }*/
}
