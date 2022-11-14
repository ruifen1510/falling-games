using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    public Transform[] shotSpawn;
    public float delayShootDuration;

    void Start()
    {
        StartCoroutine(DelayShoot());
        InvokeRepeating("Fire", fireRate, fireRate);
    }

    void Fire()
    {
        for(int i = 0; i < shotSpawn.Length; i++)
        {
            GameObject bullet = Enemy2ndBulletObjectPool.instance2.GetPooledObjects();

            bullet.transform.position = shotSpawn[i].position;
            bullet.transform.rotation = shotSpawn[i].rotation;
            bullet.SetActive(true);
        }
    }

    IEnumerator DelayShoot()
    {
        yield return new WaitForSeconds(delayShootDuration);
    }
}
