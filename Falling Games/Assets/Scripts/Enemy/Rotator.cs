using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotator : MonoBehaviour
{
    public float rotateMin = -180, rotateMax = 180;
    private float rotateSpeed;

    private GameObject player;
    public float speed = 1;
    private float stopDist = 3f;

    public GameObject explosionPrefab;

    public GameObject enemyPrefab;

    void Start()
    {
        //rotateSpeed = Random.Range(rotateMin, rotateMax);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        StartCoroutine(Delay());

        //transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);

        //if (Vector2.Distance(player.transform.position, transform.position) > stopDist)
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = player.transform.position;
            //Destroy(explosion, 1f);

            SceneManager.LoadScene(4);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);

        enemyPrefab.transform.position = Vector2.MoveTowards(enemyPrefab.transform.position, player.transform.position, speed * Time.deltaTime);

    }
}
