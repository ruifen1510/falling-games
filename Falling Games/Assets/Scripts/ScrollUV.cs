using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    private SpriteRenderer bg;
    private Vector2 offset;

    void Start()
    {
        bg = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        offset = new Vector2(offset.x += x * Time.deltaTime * 0.5f, offset.y += y * Time.deltaTime * 1.5f);
        bg.material.SetTextureOffset("_MainTex", offset);
    }
}
