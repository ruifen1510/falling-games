using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        PlayerDies();
        LowHealthAlert();
    }

    void ReduceHealthBar()
    {
            healthBar.fillAmount = health / maxHealth;
            //Debug.Log(health);
    }

    void PlayerDies()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    void LowHealthAlert()
    {
        if(healthBar.fillAmount <= 0.3f)
        {
            warning.SetActive(true);
        }
    }
}
