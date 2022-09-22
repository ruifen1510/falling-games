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
    [SerializeField] private float speed = 2f;

    //rotation
    private Vector2 mousePos;

    //shooting
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float fireRate = 0.3f;
    private float nextFire;

    //bubble shield
    /*[SerializeField] private GameObject bubble;
    private GameObject instance;
    private bool isShieldActive;*/
    //[SerializeField] private Transform bubblePoint;

    void Start()
    {
        cam = Camera.main;
        rgb = GetComponent<Rigidbody2D>();

        //bubble.SetActive(false);
        /*instance = (GameObject)Instantiate(bubble); //Spawn a copy of 'prefab' and store a reference to it.
        instance.SetActive(false);*/
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
            nextFire = Time.time + fireRate;
            Shoot();
        }

        //bubble shield
        /*if(Input.GetKey(KeyCode.B))
        {
            instance.SetActive(true);
            instance.transform.parent = gameObject.transform;
            instance.transform.position = gameObject.transform.position;
            Debug.Log("activated");
        }*/
    }

    void FixedUpdate()
    {
        //movement
        rgb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        //rotation
        Vector2 lookDir = mousePos - rgb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rgb.rotation = angle;
    }

    //shooting
    private void Shoot()
    {
        GameObject bullet = PlayerObjPool.instance.GetPooledObj();

        if(bullet != null)
        {
            bullet.transform.position = shootingPoint.position;
            bullet.transform.rotation = shootingPoint.rotation;
            bullet.SetActive(true);
        }
    }
}
