using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject playerExplosion;
    public GameObject player;

    public AudioClip bubbleFullSound;
    private bool alreadyPlayedBubbleSound;

    public AudioClip lowHealthSound;
    private bool alreadyPlayedLowHealthSound;


    //public GameObject[] bomb;
    //public float timeToSpawnBomb = 3f;
    //public float spawnRadius = 7f;

    void Start()
    {
        //StartCoroutine(BombSpawner());
        playerExplosion.SetActive(false);

        GetComponent<AudioSource>().playOnAwake = false;

        alreadyPlayedBubbleSound = false;
        alreadyPlayedLowHealthSound = false;

    }

    void Update()
    {
        StartCoroutine(PlayerDead());

        PlaySound();
    }

    IEnumerator PlayerDead()
    {
        if (HealthBar.health <= 0)
        {
            playerExplosion.SetActive(true);

            yield return new WaitForSeconds(0.8f);

            Destroy(player);

            yield return new WaitForSeconds(1.5f);

            SceneManager.LoadScene("GameOver");
        }
    }

    private void PlaySound()
    {
        if(BubbleShield.shieldBar.fillAmount == 1f)
        {
            if(alreadyPlayedBubbleSound == false)
            {
                //GetComponent<AudioSource>().clip = bubbleFullSound;
                //GetComponent<AudioSource>().Play();

                GetComponent<AudioSource>().PlayOneShot(bubbleFullSound);

                alreadyPlayedBubbleSound = true;
            }
        }
        else
        {
            alreadyPlayedBubbleSound = false;
        }

        if(HealthBar.healthBar.fillAmount <= 0.3f)
        {
            if(alreadyPlayedLowHealthSound == false)
            {
                GetComponent<AudioSource>().PlayOneShot(lowHealthSound);

                alreadyPlayedLowHealthSound = true;
            }
        }
    }


    /*IEnumerator BombSpawner()
    {
        Vector2 spawnPos = player.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        yield return new WaitForSeconds(timeToSpawnBomb);
        Instantiate(bomb[Random.Range(0, bomb.Length)], spawnPos, Quaternion.identity);
    }*/
}
