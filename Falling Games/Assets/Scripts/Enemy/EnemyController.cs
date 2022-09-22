using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rgb;

    private int hitCount;

    //movement
    [SerializeField] float moveTime = 2f, speed = 0.5f, moveRadius = 3f;

    [SerializeField] private GameObject explosion;

    private GameObject player;

    //shooting
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float fireRate = 0.3f;
    float nextFire;

    //movement
    private Vector2 movement;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float stopDist = 5f;

    [SerializeField] private GameObject explodePrefab;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        hitCount = 0;

        player = GameObject.Find("Player");

        StartCoroutine(IdleMovement());

        nextFire = Time.time;

        //Rotation();
    }

    void Update()
    {
        //rotation
        Vector3 direction = player.transform.position - transform.position;

        //value should become closer to 0 as player moves nearer towards enemy
        //Debug.Log(direction);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rgb.rotation = angle;

        CheckHitCount();


        CheckIfTimeToFire();


        //movement
        direction.Normalize();
        movement = direction;
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
        if (hitCount >= 5)
        {
            GameObject explosion = (GameObject)Instantiate(explodePrefab);
            explosion.transform.position = transform.position;
            gameObject.SetActive(false);
            /*Instantiate(explosion, transform.position, transform.rotation);
                Destroy(explosion, 1f);*/
       
        }
    }

    //movement
    IEnumerator IdleMovement()
    {
        Vector3 moveDirection = Random.insideUnitCircle.normalized * moveRadius;

        while (moveTime > 0)
        {
            moveTime -= Time.deltaTime;
            rgb.MovePosition(transform.position + speed * moveDirection * Time.deltaTime);
            yield return null;
        }
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
            nextFire = Time.time + fireRate;

            GameObject bullet = EnemyObjPool.instance.GetPooledObj();

            if (bullet != null)
            {
                bullet.transform.position = shootingPoint.position;
                bullet.transform.rotation = shootingPoint.rotation;
                bullet.SetActive(true);
            }
        }
    }

    //movement
    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    //movement
    void MoveEnemy(Vector2 direction)
    {
        //enemy stops at certain distance from player
        if (Vector2.Distance(player.transform.position, transform.position) > stopDist)
            rgb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
