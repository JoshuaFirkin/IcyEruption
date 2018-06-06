using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public int playerCount = 1;
    public int playerOneChar = 1;
    public RuntimePlatform map = RuntimePlatform.XboxOne;

    void Start()
    {
        // Spawns both players upon starting game.
        // WHEN THE GAME IS IMPLEMENTED, CHANGE THIS.
        SpawnPlayers();
    }


    void SpawnPlayers()
    {
        // The number of players is decided on here.
        switch (playerCount)
        {
            case 1:
                // Finds the chosen guy and sets them as player 1.
                FindCharacterOnScene(playerOneChar).GetComponent<PlayerController>().SetPlayerInfo(map, 1);
                break;

            case 2:
                // Sets the fire guy as player 1 and the ice guy as player 2.
                FindCharacterOnScene(1).GetComponent<PlayerController>().SetPlayerInfo(map, 1);
                FindCharacterOnScene(2).GetComponent<PlayerController>().SetPlayerInfo(map, 2);
                break;

            default:
                // Finds the chosen guy and sets them as player 1.
                FindCharacterOnScene(playerOneChar).GetComponent<PlayerController>().SetPlayerInfo(map, 1);
                break;
        }
    }


    GameObject FindCharacterOnScene(int character)
    {
        // Switches depending on which character player 1 chose.
        if (character == 1)
        {
            Debug.Log("Found Fire");
            return GameObject.FindObjectOfType<FireMotor>().gameObject;
        }
        else if (character == 2)
        {
            Debug.Log("Found Ice");
            return GameObject.FindObjectOfType<IceMotor>().gameObject;
        }
        else
        {
            return null;
        }
    }
}
