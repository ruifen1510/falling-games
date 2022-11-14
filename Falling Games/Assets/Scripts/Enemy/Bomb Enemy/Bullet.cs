using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDir;
    public float moveSpeed = 10f;

    [SerializeField] private float shieldDamageAmount = 15f;

    void OnEnable()
    {
        Invoke("Destroy", 3f); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDir = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    //[SerializeField] private Rigidbody2D rgb;
    //[SerializeField] private float force = 0.5f;

    [SerializeField] private int damageAmt = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Bubble")
        {
            gameObject.SetActive(false);
        }

        if(col.gameObject.tag == "Player" && PlayerController.isShieldActive == false)
        {   
            if(ShieldBar.stamina > 0f)
            {
               ShieldBar.stamina -= shieldDamageAmount;
            }
            else
            {
                HealthBar.health -= damageAmt;
                gameObject.SetActive(false);
            }
        }
    }
}
