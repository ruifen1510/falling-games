using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage bg;
    [SerializeField] private float x, y;

    void Update()
    {
        bg.uvRect = new Rect(bg.uvRect.position + new Vector2(x, y) * Time.deltaTime, bg.uvRect.size);
    }
}
