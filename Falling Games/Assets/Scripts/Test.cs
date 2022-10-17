using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //movement
    private float horizontalInput;
    private float verticalInput;

    public float maxSpeed = 5f;
    public float acelTime = 2.5f;
    float accelRatePerSec;
    float forwardVelocity;
    
    private Rigidbody2D rgb;

    [SerializeField] private float movingSpeed = 2f;

    private void Start()
    {
        rgb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        //movement
        //rgb.velocity = new Vector2(horizontalInput * movingSpeed, verticalInput * movingSpeed);

        float acceleration = maxSpeed / acelTime;

        float movingSpeed = acceleration * Time.deltaTime;

        if (movingSpeed > maxSpeed)
        {
            movingSpeed = maxSpeed;
        }

        Vector2 velocity = new Vector2(movingSpeed * horizontalInput * Time.deltaTime, movingSpeed * verticalInput * Time.deltaTime);

        rgb.velocity = velocity;

        Debug.Log(movingSpeed);

    }
}