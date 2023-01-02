using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickPlayer : MonoBehaviour
{
    public AudioClip clickPlayerSound;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }
    public void PlayerClicked()
    {
        GetComponent<AudioSource>().clip = clickPlayerSound;
        GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("Loading");
    }

    public void PlayerHover()
    {
        gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,0.8f);
    }

    public void PlayerExit()
    {
        gameObject.GetComponent<Image>().color = Color.white;
    }
}
