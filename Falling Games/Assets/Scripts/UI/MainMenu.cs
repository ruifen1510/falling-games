using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioClip buttonClickSound;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    public void Play()
    {
        GetComponent<AudioSource>().clip = buttonClickSound;
        GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("Narrative");
    }

    public void HowToPlay()
    {
        GetComponent<AudioSource>().clip = buttonClickSound;
        GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("HowToPlay");
    }

    public void StartOver()
    {
        GetComponent<AudioSource>().clip = buttonClickSound;
        GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("Narrative");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        GetComponent<AudioSource>().clip = buttonClickSound;
        GetComponent<AudioSource>().Play();

        Application.Quit();
    }

    public void Back()
    {
        GetComponent<AudioSource>().clip = buttonClickSound;
        GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("MainMenu");
    }
}
