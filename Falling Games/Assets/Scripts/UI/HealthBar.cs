using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static Image healthBar;
    public static float health;
    
    private float maxHealth;

    [SerializeField] private GameObject warning;
    [SerializeField] private float lowHealthThreshold = 0.3f;

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
    }

    void LowHealthAlert()
    {
        if(healthBar.fillAmount <= lowHealthThreshold)
        {
            warning.SetActive(true);
        }
    }
}
