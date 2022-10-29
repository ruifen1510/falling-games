using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    private Rigidbody2D rgb;
    //[SerializeField] private float force = 0.1f;

    [SerializeField] private int damageAmt = 10;


    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rgb.velocity = transform.up * speed;

    }

    /*private void LateUpdate()
    {
        rgb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }*/

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Bubble")
        {
            gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "Player" && PlayerController.isShieldActive == false)
        {
            HealthBar.health -= damageAmt;
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        rgb.gameObject.SetActive(false);
    }
}
