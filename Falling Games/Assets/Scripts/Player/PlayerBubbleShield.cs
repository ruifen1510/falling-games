using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBubbleShield : MonoBehaviour
{
    private int hitCount;

    void Start()
    {
        hitCount = 0;
    }

    void Update()
    {
        if (hitCount == 2)
        {
            gameObject.SetActive(false);
            PlayerController.isShieldActive = false;
            
            hitCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy Bullet")
        {
            hitCount += 1;
        }
    }
}
