using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSelectedPlayer : MonoBehaviour
{
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        players[CharacterSelectionMenu.characterSelection.selectedCharacter].SetActive(true);
    }
}
