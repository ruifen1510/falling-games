using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static Image healthBar;
    private float maxHealth;
    public static float health;

    public GameObject warning;

    //public AudioClip lowHealthSound;

    public float lowHealthThreshold = 0.3f;

    void Start()
    {
        maxHealth = 100f;
        healthBar = GetComponent<Image>();
        health = maxHealth;

        warning.SetActive(false);

        //GetComponent<AudioSource>().playOnAwake = false;
    }

    void Update()
    {
        ReduceHealthBar();
        LowHealthAlert();
        //LowHealthSound();
    }

    void ReduceHealthBar()
    {
            healthBar.fillAmount = health / maxHealth;
            //Debug.Log(health);
    }

    void LowHealthAlert()
    {
        if(healthBar.fillAmount <= lowHealthThreshold)
        {
            warning.SetActive(true);
        }
    }

    /*void LowHealthSound()
    {
        if(warning.activeSelf == true)
        {
            //GetComponent<AudioSource>().clip = lowHealthSound;
            //GetComponent<AudioSource>().Play();

            alert.clip = lowHealthSound;
            alert.Play();
        }
    }*/
}
