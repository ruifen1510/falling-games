using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgb;

    [SerializeField] private int damageAmt = 10;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rgb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Bubble")
        {
            gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "Player" && PlayerController.isShieldActive == false)
        {
            HealthBar.health -= damageAmt;
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
