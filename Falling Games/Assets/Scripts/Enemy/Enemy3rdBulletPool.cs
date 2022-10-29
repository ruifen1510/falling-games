using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3rdBulletPool : MonoBehaviour
{
    public static Enemy3rdBulletPool instance3;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 50;

    [SerializeField] private GameObject bulletPrefab3;

    void Awake()
    {
        if (instance3 == null)
        {
            instance3 = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab3);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObjects()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
