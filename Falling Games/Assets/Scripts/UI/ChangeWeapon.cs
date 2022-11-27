using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private Image weapon1Selector;
    [SerializeField] private Image weapon2Selector;

    [SerializeField] private Sprite selected;
    [SerializeField] private Sprite unselected;

    void Start()
    {
        weapon1Selector.sprite = selected;
        weapon2Selector.sprite = unselected;
    }

    void Update()
    {
        PlayerController playerController = new PlayerController();
        playerController.DetectLastKeyPressed();
        SwitchWeaponSelection();
    }

    void SwitchWeaponSelection()
    {
        if(PlayerController.currBulletIndex == 1)
        {
            weapon1Selector.sprite = selected;
            weapon2Selector.sprite = unselected;
        }
        else if (PlayerController.currBulletIndex > 1)
        {
            weapon1Selector.sprite = unselected;
            weapon2Selector.sprite = selected;
        }
    }

    
}
