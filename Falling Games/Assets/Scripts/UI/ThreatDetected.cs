using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreatDetected : MonoBehaviour
{

    public int flickerAmount = 3;
    public float flickerTime = 0.5f;

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.enabled = true;

        StartCoroutine(BlinkingAlert());
    }

    IEnumerator BlinkingAlert()
    {
        for (int i = 0; i < flickerAmount; i++)
        {
            text.color = new Color(1f, 0f, 0f, 1f);
            yield return new WaitForSeconds(flickerTime);

            text.color = new Color(1f, 0f, 0f, 0.5f);
            yield return new WaitForSeconds(flickerTime);
        }

        text.enabled = false;
    }
}
    
