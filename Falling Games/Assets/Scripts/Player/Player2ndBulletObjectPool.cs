using System.Collections.Generic;
using UnityEngine;

public class Player2ndBulletObjectPool : MonoBehaviour
{
    public static Player2ndBulletObjectPool instance2;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 10;

    [SerializeField] private GameObject bulletPrefab2;

    void Awake()
    {
        if (instance2 == null)
        {
            instance2 = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab2);
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
