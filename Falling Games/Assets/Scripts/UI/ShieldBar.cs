using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public static Image staminaBar;
    private float maxStamina;
    public static float stamina;
    [SerializeField] private float fillSpeed;

    void Start()
    {
        maxStamina = 100f;
        staminaBar = GetComponent<Image>();
        stamina = maxStamina;

        InvokeRepeating("Recharge", 0.0f, 1f);
    }

    private void Update()
    {
        ReduceShieldBar();
    }

    void ReduceShieldBar()
    {
        staminaBar.fillAmount = stamina / maxStamina;
        //Debug.Log(stamina);
    }


    void Recharge()
    {
        if(stamina < maxStamina)
        {
            stamina += 1f;
        }
    }
}
