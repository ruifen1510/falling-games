using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public static Image shieldBar;
    public static float shield;
    
    [SerializeField] private float fillSpeed;

    void Start()
    {
        shieldBar = GetComponent<Image>();
        shield = 0f;
        shieldBar.fillAmount = shield;
    }

    void Update()
    {
        shieldBar.fillAmount = shieldBar.fillAmount + shield + fillSpeed * Time.deltaTime;

    }

    public static void Reset()
    {
        if (shieldBar.fillAmount == 1f)
        shieldBar.fillAmount = 0f;
    }
}
