using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4thBulletPool : MonoBehaviour
{
    public static Enemy4thBulletPool instance4;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 50;

    [SerializeField] private GameObject bulletPrefab4;

    void Awake()
    {
        if (instance4 == null)
        {
            instance4 = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab4);
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
