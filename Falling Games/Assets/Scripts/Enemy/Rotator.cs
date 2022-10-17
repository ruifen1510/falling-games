using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateMin = -180, rotateMax = 180;
    private float rotateSpeed;

    private Transform player;
    public float speed = 1;
    private float stopDist = 3f;

    void Start()
    {
        rotateSpeed = Random.Range(rotateMin, rotateMax);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        
        if (Vector2.Distance(player.transform.position, transform.position) > stopDist)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
