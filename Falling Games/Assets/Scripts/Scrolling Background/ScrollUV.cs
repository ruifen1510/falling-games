using UnityEngine;

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
}
