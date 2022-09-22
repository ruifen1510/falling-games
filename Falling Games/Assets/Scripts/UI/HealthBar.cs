using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    private float maxHealth = 100f;
    public static float health;


    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }

    void Update()
    {
        ReduceHealthBar();
        PlayerDies();
    }

    void ReduceHealthBar()
    {
        if(ShieldBar.shield == 0)
        {
            healthBar.fillAmount = health / maxHealth;
            //Debug.Log(health);
        }
    }

    void PlayerDies()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
