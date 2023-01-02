using System.Collections;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    private Rigidbody2D rgb;
    private float fireRate;
    private float canFire = 2f;
    private GameObject player;
    private bool isFiring;
    private int hitCount;
    private Animator animator;

    [SerializeField] private GameObject laserBeam;
    [SerializeField] private float speed = 4f, stopDist = 5f;
    [SerializeField] private float minSpeed = 45f, maxSpeed = 90f;
    [SerializeField] private int noOfLives = 20;
    [SerializeField] private GameObject explosionPrefab;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        laserBeam.SetActive(false);

        isFiring = false;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //follows player
        if (Vector2.Distance(player.transform.position, transform.position) > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        StartCoroutine(LaserEnemyFire());

        LaserActive();

        CheckHitCount();
    }

    private void FixedUpdate()
    {
        Rotation();
    }

    void Rotation()
    {
        if(isFiring == false)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();

            float rotateSpeed = Random.Range(minSpeed, maxSpeed);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion desiredRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotateSpeed * Time.deltaTime);
        }
    }

    IEnumerator LaserEnemyFire()
    {
        if(Time.time > canFire)
        {
            laserBeam.SetActive(true);

            fireRate = Random.Range(2f, 4f);
            canFire = Time.time + fireRate;

            yield return new WaitForSeconds(0.5f);

            laserBeam.SetActive(false);
        }
    }

    void LaserActive()
    {
        if(laserBeam.activeSelf == false)
        {
            isFiring = false;
        }
        else
        {
            isFiring = true;
        }
    }

    //when enemy got hit by player's bullets
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerController playerController = new PlayerController();

        if (col.gameObject.tag == "Bullet")
        {
            hitCount += playerController.weapon1Damage;
            CameraShake.instance.ShakeCamera();
        }
        if (col.gameObject.tag == "Bullet2")
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
