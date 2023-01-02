using UnityEngine;

public class CircleBullet : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" | collision.tag == "Bubble")
        {
            gameObject.SetActive(false);
        }
    }
}
