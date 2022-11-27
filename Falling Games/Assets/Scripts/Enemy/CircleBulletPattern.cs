using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBulletPattern : MonoBehaviour
{
    [SerializeField] private float radius = 25f, initialSpeed = 100f;
    [SerializeField] private int noOfBullets = 7;
    [SerializeField] private Transform shootingPoint;
    public float speed = 4f;
    public float stopDist = 4f;

    private Transform player;
    private Rigidbody2D rgb;
    private float nextFire;
    private float fireTime = 1f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Fire();
        Rotation();
        FollowPlayer();
    }

    void Rotation()
    {
        Vector3 direction = player.transform.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rgb.rotation = angle;
    }

    void FollowPlayer()
    {
        if (Vector2.Distance(player.transform.position, transform.position) > stopDist)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireTime;

            //Vector3 direction = shootingPoint.position - transform.position;
            //direction.Normalize();
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            float playerRotation = 90;
            //Vector2 dir = player
            //float playerRotation =  (player.position - transform.position).rotation;

            float i_angle = 360 / noOfBullets;

            for (int i = 0; i < noOfBullets; ++i)
            {
                //x & y target should be calculated from the angle of the mouse and player
                float x = Mathf.Cos((playerRotation) * (Mathf.PI / 180)) * initialSpeed + radius * Mathf.Sin((-playerRotation - i_angle * i + 90) * Mathf.PI / 180);
                float y = Mathf.Sin((playerRotation) * (Mathf.PI / 180)) * initialSpeed + radius * Mathf.Cos((-playerRotation - i_angle * i + 90) * Mathf.PI / 180);
                float speed = Mathf.Sqrt(x * x + y * y);
                //float rotation = 0;
                //if (y == 0)
                //{
                //    rotation = Mathf.Acos((speed * speed + y * y - x * x) / (2 * speed * 1));
                //}
                //else
                //{
                //    rotation = Mathf.Acos((speed * speed + y * y - x * x) / (2 * speed * y));
                //}

                //GameObject bullet = Enemy4thBulletPool.instance4.GetPooledObjects();
                GameObject bullet = Enemy4thBulletPool.instance4.GetPooledObjects();
                //bullet.transform.position.Set(transform.position.x, transform.position.y, transform.position.z);
                //bullet.transform.eulerAngles.z = new Vector3(0, 0, rotation);

                //Transform bulletTransform = bullet.GetComponent<Transform>();
                //bulletTransform.rotation.z = rotation;
                bullet.transform.position = shootingPoint.transform.position;
                //bullet.transform.Rotate(0, 0, rotation);

                bullet.SetActive(true);

                Rigidbody2D rgb = bullet.GetComponent<Rigidbody2D>();

                rgb.velocity = new Vector2(x, y);
            }
        }
    }
}