using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBubble : MonoBehaviour
{
    void Update()
    {
        if (ShieldBar.shield == 0)
        {
            Destroy(gameObject);
        }
    }
}
