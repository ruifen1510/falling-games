using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombMove : MonoBehaviour
{
    public float rotateMin = -180, rotateMax = 180;
    private float rotateSpeed;

    private GameObject player;
    public float speed = 1;
    public float stopDist = 3f;

    public GameObject explosionPrefab;

    public GameObject enemyPrefab;

    private int hitCount;
    [SerializeField] private int noOfLives = 20;

    void Start()
    {
        hitCount = 0;

        rotateSpeed = Random.Range(rotateMin, rotateMax);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        //StartCoroutine(Delay());

        if(enemyPrefab.name == "Bomb")
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);

        }

        if (Vector2.Distance(player.transform.position, transform.position) > stopDist)
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        CheckHitCount();
    }

    //Player loses if collides with bomb
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*if(collision.tag == "Player")
        {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = player.transform.position;
            //Destroy(explosion, 1f);

            SceneManager.LoadScene(4);
        }*/

        PlayerController playerController = new PlayerController();

        if (col.gameObject.tag == "Bullet")
        {
            hitCount += playerController.weapon1Damage;
            CameraShake.instance.ShakeCamera();

            GetComponent<AudioSource>().Play();
        }
        if (col.gameObject.tag == "Bullet2")
        {
            hitCount += playerController.weapon2Damage;
            CameraShake.instance.ShakeCamera();
        }
    }

    private void CheckHitCount()
    {
        if (hitCount >= noOfLives)
        {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = transform.position;

            Destroy(gameObject);
        }
    }

    /*IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);

        enemyPrefab.transform.position = Vector2.MoveTowards(enemyPrefab.transform.position, player.transform.position, speed * Time.deltaTime);

    }*/


}
