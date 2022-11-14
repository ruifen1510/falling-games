using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionMenu : MonoBehaviour
{
    public static CharacterSelectionMenu characterSelection;

    [SerializeField] private GameObject[] playerCharacters;
    public int selectedCharacter = 0;

    [SerializeField] private Text playerText;

    void Start()
    {
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

    void NextCharacter()
    {
        playerCharacters[selectedCharacter].SetActive(false);
        selectedCharacter++;

        if(selectedCharacter >= playerCharacters.Length)
        {
            selectedCharacter = 0;
        }

        playerCharacters[selectedCharacter].SetActive(true);
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
    }

    void DisplayPlayerName()
    {
        switch(selectedCharacter)
        {
            case 0:
                playerText.text = "Amber (Angel)";
                break;
            case 1:
                playerText.text = "Terra (Human)";
                break;
            case 2:
                playerText.text = "Mako (Alien)";
                break;
            case 3:
                playerText.text = "Lily (Devil)";
                break;

        }
    }

    void SelectPlayer()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Loading");
        }
    }
}
