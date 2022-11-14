using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    private float maxHealth;
    public static float health;

    public GameObject warning;

    void Start()
    {
        maxHealth = 100f;
        healthBar = GetComponent<Image>();
        health = maxHealth;

        warning.SetActive(false);
    }

    void Update()
    {
        ReduceHealthBar();
        LowHealthAlert();
    }

    void ReduceHealthBar()
    {
            healthBar.fillAmount = health / maxHealth;
            //Debug.Log(health);
    }

    void LowHealthAlert()
    {
        if(healthBar.fillAmount <= 0.3f)
        {
            warning.SetActive(true);
        }
    }
}
