using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer sprite;

    private Rigidbody2D rgb;
    private Camera cam;

    //movement
    private float horizontalInput;
    private float verticalInput;

    private float movingSpeed;

    private SpriteRenderer playerSprite;
    private bool canTakeDamage;
    private bool hitByEnemy;
    public int flickerAmt = 2;
    public float flickerDuration = 1f;

    //acceleration
    //[SerializeField] private float maxSpeed = 5f, accelerationRate = 2.5f, maxAccelRate = 5f;

    //rotation
    private Vector2 mousePos;

    //shooting
    private float nextFire;

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float fireTime = 0.3f;

    //bubble shield
    public static bool isShieldActive;

    [SerializeField] private GameObject bubbleShield;

    void Start()
    {
        canTakeDamage = true;
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        hitByEnemy = false;

        cam = Camera.main;
        rgb = GetComponent<Rigidbody2D>();

        movingSpeed = 5f;

        isShieldActive = false;
        bubbleShield.SetActive(false);
    }

    void Update()
    {
        //movement & acceleration
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

       /*if (horizontalInput != 0 || verticalInput != 0)
        {
            accelerationRate += maxAccelRate/2 * Time.deltaTime;
            movingSpeed += accelerationRate * Time.deltaTime;
        }
        else
        {
            //accelerationRate = 0f;
            movingSpeed = 0;

        }

        if (movingSpeed > maxSpeed)
        {
            movingSpeed = maxSpeed;
        }

        if(accelerationRate > maxAccelRate)
        {
            accelerationRate = maxAccelRate;
        }

        Debug.Log(movingSpeed);*/

        //rotation
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //shooting
        if(Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireTime;
            
            GameObject bullet = PlayerObjPool.instance.GetPooledObj();

            bullet.transform.position = shootingPoint.position;
            bullet.transform.rotation = shootingPoint.rotation;
            bullet.SetActive(true);
        }

        //bubble shield
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isShieldActive && ShieldBar.shieldBar.fillAmount == 1f)
            {
                bubbleShield.SetActive(true);
                isShieldActive = true;
                
                ShieldBar.Reset();
            }
        }

        StartCoroutine(DamageFlicker());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy Bullet" && isShieldActive == false)
        {
            hitByEnemy = true;
        }
    }

    void FixedUpdate()
    {
        //movement
        rgb.velocity = new Vector2(horizontalInput * movingSpeed, verticalInput * movingSpeed);

        //rotation
        Vector2 lookDir = mousePos - rgb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rgb.rotation = angle;
    }

    IEnumerator DamageFlicker()
    {
        if(hitByEnemy == true)
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

            hitByEnemy = false;

            Debug.Log(playerSprite.color);
        }
    }
}
