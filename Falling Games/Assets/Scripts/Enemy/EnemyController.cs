using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rgb;
    private int hitCount;

    [SerializeField] private int noOfLives = 5;

    //idle movement (how much time, how fast, and how much distance enemy moves in its position
    [SerializeField] float moveTime = 2f, moveSpeed = 0.5f, moveRadius = 3f;

    private GameObject player;

    //follow player
    private Vector2 movement;

    [SerializeField] private float followSpeed = 1f, stopDist = 5f;

    //shooting
    private float nextFire;

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float fireTime = 3f;
    [SerializeField] private GameObject explodePrefab;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        
        hitCount = 0;

        player = GameObject.Find("Player");

        StartCoroutine(IdleMovement());

        nextFire = Time.time;
    }

    private IEnumerator DelayShoot()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(1f);

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        //shooting
        CheckIfTimeToFire();
        CheckHitCount();
    }

    void Update()
    {
        //rotation
        Vector3 direction = player.transform.position - transform.position;

        //value should become closer to 0 as player moves nearer towards enemy
        //Debug.Log(direction);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rgb.rotation = angle;

        //movement
        direction.Normalize();
        movement = direction;

        StartCoroutine(DelayShoot());

        /*//shooting
        CheckIfTimeToFire();
        CheckHitCount();*/
    }

    //idle movement
    IEnumerator IdleMovement()
    {
        Vector3 moveDirection = Random.insideUnitCircle.normalized * moveRadius;

        while (moveTime > 0)
        {
            moveTime -= Time.deltaTime;
            rgb.MovePosition(transform.position + moveSpeed * moveDirection * Time.deltaTime);
            yield return null;
        }
    }

    //follow player
    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    private void MoveEnemy(Vector2 direction)
    {
        //enemy stops at certain distance from player
        if (Vector2.Distance(player.transform.position, transform.position) > stopDist)
            rgb.MovePosition((Vector2)transform.position + (direction * followSpeed * Time.deltaTime));
    }

    //shooting
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            /*GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            nextFire = Time.time + fireRate;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * bulletForce * Time.deltaTime, ForceMode2D.Impulse);*/
            nextFire = Time.time + fireTime;

            GameObject bullet = EnemyObjPool.instance.GetPooledObj();

            bullet.transform.position = shootingPoint.position;
            bullet.transform.rotation = shootingPoint.rotation;
            bullet.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            hitCount += 1;
        }
    }

    private void CheckHitCount()
    {
        if (hitCount >= noOfLives)
        {
            GameObject explosion = Instantiate(explodePrefab);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
