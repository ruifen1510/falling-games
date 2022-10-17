using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rgb;
    
    [SerializeField] private float bulletForce = 1000f;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rgb.AddForce(transform.up * bulletForce * Time.deltaTime, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy2")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
