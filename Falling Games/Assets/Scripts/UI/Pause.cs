using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioClip buttonClickSound;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        GetComponent<AudioSource>().clip = buttonClickSound;
        GetComponent<AudioSource>().Play();
    }
}
