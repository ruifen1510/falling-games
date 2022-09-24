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

    void Start()
    {
        maxHealth = 100f;
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
}
