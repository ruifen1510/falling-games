using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public AudioClip typeSound;

    [SerializeField] Text textDisplay;
    [SerializeField] string[] sentences;
    [SerializeField] float typingSpeed;

    private int index; //sentence index

    void Start()
    {
        StartCoroutine(Type());

        GetComponent<AudioSource>().playOnAwake = false;
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene("PlayerSelection");
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            
            GetComponent<AudioSource>().clip = typeSound;
            GetComponent<AudioSource>().Play();
            
            yield return new WaitForSeconds(typingSpeed);
        }

        GetComponent<AudioSource>().Stop();
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            SceneManager.LoadScene("PlayerSelection");
        }
    }
}
