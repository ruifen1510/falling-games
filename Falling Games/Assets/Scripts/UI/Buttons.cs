using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Image selector;

    void Start()
    {
        selector.enabled = false;
    }


    public void EnableSelector()
    {
        selector.enabled = true;
    }

    public void DisableSelector()
    {
        selector.enabled = false;
    }
}
