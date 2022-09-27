using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    private SpriteRenderer bg;
    private Material mat;
    private Vector2 offset;
    
    [SerializeField] private float scrollTime = 5f;

    void Start()
    {
        bg = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        mat = bg.material;
        offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / scrollTime;
        offset.y = transform.position.y / transform.localScale.y / scrollTime;

        mat.mainTextureOffset = offset;
    }
}
