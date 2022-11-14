using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[DisallowMultipleComponent]
public class ScrollUV : MonoBehaviour
{
    private SpriteRenderer bg;
    
    [SerializeField] private float scrollTime = 10f;

    void Start()
    {
        bg = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Material mat = bg.material;
        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / scrollTime;
        offset.y = transform.position.y / transform.localScale.y / scrollTime;

        mat.mainTextureOffset = offset;
    }
    // Scroll the main texture based on time

    /*[Range(0,1)]
    [SerializeField] float xSpeed = 1f;
    [Range(0,1)]
    [SerializeField] float ySpeed = 1f;

    Vector2 offset = Vector2.zero;
    Material mat;

    private void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    void Scroll(Vector2 pos)
    {
        offset.x += pos.x * xSpeed;
        offset.y += pos.y * ySpeed;

        if(offset.x > 1f)
        {
            offset.x -= 1f;
        }
        else if (offset.x < -1)
        {
            offset.x += 1f;
        }

        if(offset.y > 1f)
        {
            offset.y -= 1f;
        }
        else if (offset.y < -1)
        {
            offset.y += 1f;
        }
        mat.mainTextureOffset = offset;
    }*/
}
