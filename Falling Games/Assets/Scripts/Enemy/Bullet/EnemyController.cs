using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private int noOfLives = 10;

    private Rigidbody2D rgb;
    private int hitCount;
    private float nextFire;
    private GameObject player;
    private Vector2 movement;
    private Vector3 lastPos;

    [SerializeField] float moveTime = 2f, moveSpeed = 0.5f, moveRadius = 3f; //idle movement
    [SerializeField] private float followSpeed = 1f, stopDistance = 5f;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float fireTime = 3f;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float delayShootDuration = 1f;

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
        yield return new WaitForSeconds(delayShootDuration);

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

        Vector3 dist = transform.position - lastPos;
        float currentSpeed = dist.magnitude / Time.deltaTime;

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
        }
        if(col.gameObject.tag == "Bullet2")
        {
            hitCount += playerController.weapon2Damage;
            CameraShake.instance.ShakeCamera();
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
