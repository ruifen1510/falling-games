using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBulletPattern : MonoBehaviour
{
    [SerializeField] private float radius = 25f, initialSpeed = 100f;
    [SerializeField] private int noOfBullets = 7;
    [SerializeField] private Transform shootingPoint;

    private float nextFire;
    private float fireTime = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireTime;

            //float playerRotation = shootingPoint.rotation.z;
            float playerRotation = transform.rotation.z;

            float i_angle = 360 / noOfBullets;

            for (int i = 0; i < noOfBullets; ++i)
            {
                //x & y target should be calculated from the angle of the mouse and player
                float x = Mathf.Cos((playerRotation) * (Mathf.PI / 180)) * initialSpeed + radius * Mathf.Sin((-playerRotation - i_angle * i + 90) * Mathf.PI / 180);
                float y = Mathf.Sin((playerRotation) * (Mathf.PI / 180)) * initialSpeed + radius * Mathf.Cos((-playerRotation - i_angle * i + 90) * Mathf.PI / 180);
                float speed = Mathf.Sqrt(x * x + y * y);
                float rotation = 0;
                if (y == 0)
                {
                    rotation = Mathf.Acos((speed * speed + y * y - x * x) / (2 * speed * 1));
                }
                else
                {
                    rotation = Mathf.Acos((speed * speed + y * y - x * x) / (2 * speed * y));
                }

                GameObject bullet = Enemy4thBulletPool.instance4.GetPooledObjects();

                bullet.transform.position = transform.position;
                //bullet.transform.eulerAngles.z = new Vector3(0, 0, rotation);

                Transform bulletTransform = bullet.GetComponent<Transform>();
                //bulletTransform.rotation.z = rotation;

                bulletTransform.Rotate(0, 0, rotation);

                bullet.SetActive(true);

                Rigidbody2D rgb = bullet.GetComponent<Rigidbody2D>();

                rgb.velocity = transform.up * speed;
            }
        }
    }
}
