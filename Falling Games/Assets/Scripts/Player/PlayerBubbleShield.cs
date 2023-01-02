using UnityEngine;

public class PlayerBubbleShield : MonoBehaviour
{
    private int bubbleHitCount;

    [SerializeField] private AudioClip bulletBlockSound;
    [SerializeField] private int maxHitCount = 3;

    void Start()
    {
        bubbleHitCount = 0;

        GetComponent<AudioSource>().playOnAwake = false;
    }

    void Update()
    {
        if (bubbleHitCount == maxHitCount)
        {
            gameObject.SetActive(false);
            PlayerController.isShieldActive = false;

            bubbleHitCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy Bullet")
        {
            bubbleHitCount++;

            GetComponent<AudioSource>().clip = bulletBlockSound;
            GetComponent<AudioSource>().Play();
        }
    }
}
