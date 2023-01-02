using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform[] shotSpawn;
    [SerializeField] private float delayShootDuration;

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
