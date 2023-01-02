using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] Text textDisplay;
    [SerializeField] string[] loadingText;
    [SerializeField] float typingSpeed;

    private int index; //sentence index

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == loadingText[index])
        {
            NextSentence();
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in loadingText[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (index < loadingText.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            SceneManager.LoadScene("MainGame1");
        }
    }
}
