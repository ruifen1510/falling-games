using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D rgb;
    private int hitCount;

    [SerializeField] private int noOfLives = 10;

    //idle movement (how much time, how fast, and how much distance enemy moves in its position)
    [SerializeField] float moveTime = 2f, moveSpeed = 0.5f, moveRadius = 3f;

    //follow player
    private GameObject player;
    private Vector2 movement;

    [SerializeField] private float followSpeed = 1f, stopDistance = 5f;

    //shooting
    private float nextFire;

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float fireTime = 3f;
    [SerializeField] private GameObject explosionPrefab;

    public float delayShootDuration = 1f;

    private Vector3 lastPos;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        
        hitCount = 0;

        player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(IdleMovement());

        nextFire = Time.time;

        lastPos = transform.position;
    }

    private IEnumerator DelayShoot()
    {
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        yield return new WaitForSeconds(delayShootDuration);

        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);

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

        /*//shooting
        CheckIfTimeToFire();
        CheckHitCount();*/

        StartCoroutine(DelayShoot());

        Vector3 dist = transform.position - lastPos;
        float currentSpeed = dist.magnitude / Time.deltaTime;

        /*if (currentSpeed > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }*/

        lastPos = transform.position;
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
        if (Vector2.Distance(player.transform.position, transform.position) > stopDistance)
        {
            rgb.MovePosition((Vector2)transform.position + (direction * followSpeed * Time.deltaTime));

            animator.SetBool("isMoving", true);
        }
        else
        {
            rgb.transform.position = this.transform.position;
            animator.SetBool("isMoving", false);
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
            nextFire = Time.time + fireTime;

            GameObject bullet = Enemy1BulletPool.instance.GetPooledObjects();

            bullet.transform.position = shootingPoint.position;
            bullet.transform.rotation = shootingPoint.rotation;
            bullet.SetActive(true);
        }
    }

    //when player hits enemy
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerController playerController = new PlayerController();

        if(col.gameObject.tag == "Bullet")
        {
            hitCount += playerController.weapon1Damage;
            CameraShake.instance.ShakeCamera();

            //GetComponent<AudioSource>().Play();
        }
        if(col.gameObject.tag == "Bullet2")
        {
            hitCount += playerController.weapon2Damage;
            CameraShake.instance.ShakeCamera();

            //GetComponent<AudioSource>().Play();
        }
    }

    //when enemy dies
    private void CheckHitCount()
    {
        if (hitCount >= noOfLives)
        {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
