using UnityEngine;

public class BombMove : MonoBehaviour
{
    [SerializeField] private float rotateMin = -180f, rotateMax = 180f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float stopDist = 3f;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int noOfLives = 20;

    private GameObject player;
    private float rotateSpeed;
    private int hitCount;

    void Start()
    {
        hitCount = 0;

        rotateSpeed = Random.Range(rotateMin, rotateMax);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(enemyPrefab.name == "Bomb")
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
        }

        if (Vector2.Distance(player.transform.position, transform.position) > stopDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        CheckHitCount();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerController playerController = new PlayerController();

        if (col.gameObject.tag == "Bullet")
        {
            hitCount += playerController.weapon1Damage;
            CameraShake.instance.ShakeCamera();
        }
        else if (col.gameObject.tag == "Bullet2")
        {
            hitCount += playerController.weapon2Damage;
            CameraShake.instance.ShakeCamera();
        }
    }

    private void CheckHitCount()
    {
        if (hitCount >= noOfLives)
        {
            GameObject explosion = Instantiate(explosionPrefab);
            explosion.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
