using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDir;
    public float moveSpeed = 10f;

    [SerializeField] private float shieldDamageAmount = 15f;
    [SerializeField] private int damageAmt = 1;

    void OnEnable()
    {
        Invoke("Destroy", 3f); 
    }

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
                gameObject.SetActive(false);
            }
            else
            {
                HealthBar.health -= damageAmt;
                gameObject.SetActive(false);
            }
        }
    }
}
