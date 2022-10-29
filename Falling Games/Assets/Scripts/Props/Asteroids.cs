using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    /*[SerializeField] private GameObject[] asteroidPrefab;
    private bool canSpawn;
    public int noOfAsteroids;*/

    private void Start()
    {
        //canSpawn = true;
        //noOfAsteroids = 2;
    }

    private void Update()
    {
        //AsteroidSpawn();
    }

    /*void AsteroidSpawn()
    {
        if (canSpawn)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 
                Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            
            Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], screenPosition, transform.rotation);
            
            noOfAsteroids--;

            if (noOfAsteroids == 0)
            {
                canSpawn = false;
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Enemy Bullet" ||
           collision.gameObject.tag == "Bullet2")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
