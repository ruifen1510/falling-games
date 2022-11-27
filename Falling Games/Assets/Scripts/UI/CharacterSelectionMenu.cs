using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionMenu : MonoBehaviour
{
    public static CharacterSelectionMenu characterSelection;

    [SerializeField] private GameObject[] playerCharacters;
    public static int selectedCharacter = 0;

    [SerializeField] private Text playerText;

    public AudioClip buttonClickSound;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;

        playerCharacters[selectedCharacter].SetActive(true);

        for (int player = 1; player < playerCharacters.Length; player++)
        {
            playerCharacters[player].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextCharacter();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousCharacter();
        }

        DisplayPlayerName();

        SelectPlayer();
    }

    public void RightClick()
    {
        GetComponent<AudioSource>().clip = buttonClickSound;
        GetComponent<AudioSource>().Play();

        NextCharacter();
    }

    public void LeftClick()
    {
        GetComponent<AudioSource>().clip = buttonClickSound;
        GetComponent<AudioSource>().Play();

        PreviousCharacter();
    }

    void NextCharacter()
    {
        playerCharacters[selectedCharacter].SetActive(false);
        selectedCharacter++;

        if(selectedCharacter >= playerCharacters.Length)
        {
            selectedCharacter = 0;
        }

        playerCharacters[selectedCharacter].SetActive(true);

        Debug.Log(selectedCharacter);
    }

    void PreviousCharacter()
    {
        playerCharacters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        
        if(selectedCharacter < 0)
        {
            selectedCharacter = playerCharacters.Length - 1;
        }

        playerCharacters[selectedCharacter].SetActive(true);

        Debug.Log(selectedCharacter);
    }

    void DisplayPlayerName()
    {
        switch(selectedCharacter)
        {
            case 0: //angel
                playerText.text = "Amber";
                break;
            case 1: //human
                playerText.text = "Terra";
                break;
            case 2: //alien
                playerText.text = "Mako";
                break;
            case 3: //devil
                playerText.text = "Lilith";
                break;
        }
    }

    void SelectPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(selectedCharacter <= 1)
            {
                SceneManager.LoadScene("Loading");
            }
        }
    }
}
