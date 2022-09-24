using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgb;
    [SerializeField] private float bulletForce = 0.5f;
    [SerializeField] private int damageAmt = 10;

    private void LateUpdate()
    {
        rgb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Bubble")
        {
            gameObject.SetActive(false);
        }

        if(col.gameObject.tag == "Player" && PlayerController.isShieldActive == false)
        {
            HealthBar.health -= damageAmt;
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
