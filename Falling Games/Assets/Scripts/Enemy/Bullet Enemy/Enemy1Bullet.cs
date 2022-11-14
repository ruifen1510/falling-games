using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgb;
    [SerializeField] private float force = 0.5f;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float shieldDamageAmount = 5f;

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

        //&& shieldbar fill is more than 0f
        if(col.gameObject.tag == "Player" && PlayerController.isShieldActive == false)
        {
            if(ShieldBar.stamina > 0f)
            {
                ShieldBar.stamina -= shieldDamageAmount;
            }
            else
            {
                HealthBar.health -= damageAmount;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
