using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    private SpriteRenderer bg;
    private Material mat;
    private Vector2 offset;

    void Start()
    {
        bg = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        mat = bg.material;
        offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / 2f;
        offset.y = transform.position.y / transform.localScale.y / 2f;

        mat.mainTextureOffset = offset;
    }
}
