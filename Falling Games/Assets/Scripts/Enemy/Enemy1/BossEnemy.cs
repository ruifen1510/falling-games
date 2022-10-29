using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    //private int hitCount;
    [SerializeField] private GameObject boss;
    [SerializeField] private float timeTillNewScene = 2f;

    void Start()
    {
        //hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (hitCount == 7) //based on boss enemy's no of lives
        //{
            //StartCoroutine(DelayEnding());
        //}
        //Debug.Log(hitCount);*/

        if(EnemySpawner.isBossDead == true)
        {
            StartCoroutine(DelayEnding());
            EnemySpawner.isBossDead = false;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            ++hitCount;
        }
    }*/

    private IEnumerator DelayEnding()
    {//Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeTillNewScene);

        //After we have waited 2 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        SceneManager.LoadScene(3);
    }
}
