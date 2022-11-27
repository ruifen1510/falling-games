using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //private GameObject target;
    [SerializeField] private float speed = 0.2f;

    void Update()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector3 targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        //Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, speed);
    }
}
