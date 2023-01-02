using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;
    public static int currBulletIndex;
    public static bool isShieldActive;

    private SpriteRenderer sprite;
    private Rigidbody2D rgb;
    private Camera cam;
    private Vector2 mousePos;
    private float horizontalInput;
    private float verticalInput;
    private float nextFire;
    private Animator animator;

    [Header("Audio")]
    public AudioClip weapon1Sound;
    public AudioClip weapon2Sound;
    public AudioClip weaponSwitchSound;
    public AudioClip shieldActivationSound;
    public AudioClip playerHitSound;

    [Header("Movement")]
    [SerializeField] private float speed = 5f;

    [Header("Shooting")]
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float weapon1FireTime = 0.3f;
    [SerializeField] private float weapon2FireTime = 0.7f;

    [Header("Bubble Shield")]
    [SerializeField] private GameObject bubbleShield;

    [Header("Damage")]
    [SerializeField] private int flickerAmount = 3;
    [SerializeField] private float flickerTime = 0.3f;
    public int weapon1Damage = 1;
    public int weapon2Damage = 2;

    [Header("Animation Controllers")]
    [SerializeField] private RuntimeAnimatorController[] animControllers;

    [Header("Particle System")]
    public ParticleSystem ps;

    void Start()
    {
        if(CharacterSelectionMenu.selectedCharacter == 0)
        {
            animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = animControllers[0];
        }
        else if(CharacterSelectionMenu.selectedCharacter == 1)
        {
            animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = animControllers[1];
        }
        else if (CharacterSelectionMenu.selectedCharacter == 2)
        {
            animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = animControllers[2];
        }
        else if (CharacterSelectionMenu.selectedCharacter == 3)
        {
            animator = GetComponent<Animator>();
            animator.runtimeAnimatorController = animControllers[3];
        }

        cam = Camera.main;
        rgb = GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        isShieldActive = false;
        bubbleShield.SetActive(false);
        currBulletIndex = 1;

        GetComponent<AudioSource>().playOnAwake = false;
    }

    void Update()
    {
        //rotation
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButton("Vertical"))
        {
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")));
            ps.Play();
        }
        else if (Input.GetButton("Horizontal"))
        {
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
            ps.Play();
        }
        else
        {
            animator.SetFloat("Speed", 0f);
            ps.Stop();
        }

        DetectLastKeyPressed();
        SwitchWeapons();

        //bubble shield
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isShieldActive && BubbleShield.shieldBar.fillAmount == 1f)
            {
                bubbleShield.SetActive(true);
                isShieldActive = true;

                GetComponent<AudioSource>().clip = shieldActivationSound;
                GetComponent<AudioSource>().Play();

                BubbleShield.Reset();
            }
        }
    }

    void FixedUpdate()
    {
        //movement
        rgb.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        //rotation
        Vector2 lookDir = mousePos - rgb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rgb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy Bullet" && isShieldActive == false)
        {
            GetComponent<AudioSource>().clip = playerHitSound;
            GetComponent<AudioSource>().Play();

            StartCoroutine(DamageFlicker());
        }
    }

    IEnumerator DamageFlicker()
    {

        for (int i = 0; i < flickerAmount; i++)
        {
            sprite.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(flickerTime);
                
            sprite.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(flickerTime);
        }
    }

    public void DetectLastKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currBulletIndex = 1;

            GetComponent<AudioSource>().clip = weaponSwitchSound;
            GetComponent<AudioSource>().Play();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currBulletIndex++;

            GetComponent<AudioSource>().clip = weaponSwitchSound;
            GetComponent<AudioSource>().Play();
        }
    }

    //shooting
    void SwitchWeapons()
    {
        if (currBulletIndex == 1)
        {
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
            {
                nextFire = Time.time + weapon1FireTime;

                GameObject bullet = PlayerBulletObjectPool.instance.GetPooledObjects();

                bullet.transform.position = shootingPoint.position;
                bullet.transform.rotation = shootingPoint.rotation;
                bullet.SetActive(true);
                
                GetComponent<AudioSource>().clip = weapon1Sound;
                GetComponent<AudioSource>().Play();
            }
        }
        else if (currBulletIndex > 1)
        {
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
            {
                nextFire = Time.time + weapon2FireTime;

                GameObject bullet2 = Player2ndBulletObjectPool.instance2.GetPooledObjects();

                bullet2.transform.position = shootingPoint.position;
                bullet2.transform.rotation = shootingPoint.rotation;
                bullet2.SetActive(true);

                GetComponent<AudioSource>().clip = weapon2Sound;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
