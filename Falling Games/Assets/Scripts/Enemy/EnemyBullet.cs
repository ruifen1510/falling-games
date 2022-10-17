using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgb;
    [SerializeField] private float bulletForce = 0.5f;
    [SerializeField] private int damageAmt = 10;

    private void Start()
    {
        //canTakeDamage = true;
        //SpriteRenderer playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }

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
            //StartCoroutine(DamageFlicker());
            
            HealthBar.health -= damageAmt;
            gameObject.SetActive(false);
        }
    }

    /*private SpriteRenderer playerSprite;
    private bool canTakeDamage;
    public int flickerAmt = 2;
    public float flickerDuration = 1f;

    IEnumerator DamageFlicker()
    {
        canTakeDamage = false;

        for (int i = 0; i < flickerAmt; i++)
        {
            playerSprite.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(flickerDuration);
            playerSprite.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(flickerDuration);
            canTakeDamage = true;
        }

        Debug.Log(playerSprite.color);
    }*/

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
