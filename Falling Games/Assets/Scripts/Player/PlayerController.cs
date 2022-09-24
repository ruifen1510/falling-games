using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rgb;
    private Camera cam;

    //movement
    private float horizontalInput;
    private float verticalInput;
    
    [SerializeField] private float movingSpeed = 2f;

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
        cam = Camera.main;
        rgb = GetComponent<Rigidbody2D>();

        isShieldActive = false;
        bubbleShield.SetActive(false);
    }

    void Update()
    {
        //movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
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
}
