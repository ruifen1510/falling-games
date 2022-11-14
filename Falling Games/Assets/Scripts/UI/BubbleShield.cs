using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Didn't change this script

public class BubbleShield : MonoBehaviour
{
    public static Image shieldBar;
    public static float shield;
    
    [SerializeField] private float fillSpeed;

    [SerializeField] private Image bubbleShieldSelector;
    [SerializeField] private Color bubbleShieldColor;


    void Start()
    {
        shieldBar = GetComponent<Image>();
        shield = 0f;
        shieldBar.fillAmount = shield;

        bubbleShieldColor.a = 0.5f;
    }

    void Update()
    {
        shieldBar.fillAmount = shieldBar.fillAmount + shield + fillSpeed * Time.deltaTime;

        //ChangeSelectorColor();
    }

    public static void Reset()
    {
        if (shieldBar.fillAmount == 1f)
        shieldBar.fillAmount = 0f;
    }

    /*void ChangeSelectorColor()
    {
        if(PlayerController.isShieldActive == false)
        {
            bubbleShieldColor.a = 0.5f;
            bubbleShieldSelector.color = bubbleShieldColor;

            //Debug.Log("shield not active!");
        }
        else
        {
            bubbleShieldColor.a = 1f;
            bubbleShieldSelector.color = bubbleShieldColor;

            //Debug.Log("shield active!");

        }
    }*/
}
