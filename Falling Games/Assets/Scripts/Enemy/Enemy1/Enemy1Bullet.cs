using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgb;
    [SerializeField] private float force = 0.5f;
    [SerializeField] private int damageAmount = 10;

    private void LateUpdate()
    {
        rgb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Bubble")
        {
            gameObject.SetActive(false);
        }

        if(col.gameObject.tag == "Player" && PlayerController.isShieldActive == false)
        {   
            HealthBar.health -= damageAmount;
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
