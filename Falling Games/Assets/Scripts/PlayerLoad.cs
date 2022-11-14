using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLoad : MonoBehaviour
{
    public Image player;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Animation>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
