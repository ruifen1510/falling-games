using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    private Image shieldBar;
    private float maxShield = 100f;
    public static float shield;

    void Start()
    {
        shieldBar = GetComponent<Image>();
        shield = maxShield;
    }

    void Update()
    {
        shieldBar.fillAmount = shield / maxShield;
        Debug.Log(shield);
    }
}
