using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionMenu : MonoBehaviour
{
    public static CharacterSelectionMenu characterSelection;
    public static int selectedCharacter = 0;

    [SerializeField] private GameObject[] playerCharacters;
    [SerializeField] private Text playerText;
    [SerializeField] private AudioClip buttonClickSound;

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
}
