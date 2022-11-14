/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShooting : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float fireTime = 3f;
    private float nextFire;

    [SerializeField] private float speed;
    [SerializeField] private float radius;

    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireTime;

            GameObject bullet = Enemy4thBulletPool.instance4.GetPooledObjects();

            bullet.transform.position = shootingPoint.position;
            bullet.transform.rotation = shootingPoint.rotation;
            bullet.SetActive(true);

            bullet.velocity = transform.up * speed;
        }
    }
}*/
