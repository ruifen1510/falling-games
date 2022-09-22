using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;


    [SerializeField] private float bulletForce = 1000f;


    private void FixedUpdate()
    {
        rb.AddForce(transform.up * bulletForce * Time.deltaTime, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "Asteroid")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
