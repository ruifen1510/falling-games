using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private int damageAmt = 10;
    [SerializeField] private float shieldDamageAmount = 15f;

    private Rigidbody2D rgb;

    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
            if (ShieldBar.stamina > 0f)
            {
                ShieldBar.stamina -= shieldDamageAmount;
                gameObject.SetActive(false);
            }
            else
            {
                HealthBar.health -= damageAmt;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
