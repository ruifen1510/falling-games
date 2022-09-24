using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    private int hitCount;

    void Start()
    {
        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitCount == 7)
        {
            SceneManager.LoadScene(2);
        }
        //Debug.Log(hitCount);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            ++hitCount;
        }
    }
}
