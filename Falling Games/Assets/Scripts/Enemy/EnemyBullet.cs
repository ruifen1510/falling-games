using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        //Destroy(gameObject, 1.5f);
    }

    [SerializeField] private float bulletForce = 1000f;

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * bulletForce * Time.deltaTime, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Asteroid")
        {
            gameObject.SetActive(false);
        }

        if(col.gameObject.tag == "Player")
        {
            HealthBar.health -= 10f;
        }

        if(col.gameObject.tag == "Bubble")
        {
            ShieldBar.shield -= 10f;
        }

    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
