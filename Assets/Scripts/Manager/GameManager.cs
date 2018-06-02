using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool overridePlayerCount = false;
    public int playerCount = 2;
    public RuntimePlatform map = RuntimePlatform.XboxOne;

    void Start()
    {
        if (overridePlayerCount)
        {
            SpawnPlayers(playerCount);
        }
        else
        {
            SpawnPlayers();
        }
    }

    void SpawnPlayers()
    {
        Debug.Log(Input.GetJoystickNames());
        switch (Input.GetJoystickNames().Length)
        {
            case 1:
                FindCharacterOnScene(true).GetComponent<PlayerController>().SetPlayerInfo(map, 1);
                break;

            case 2:
                FindCharacterOnScene(true).GetComponent<PlayerController>().SetPlayerInfo(map, 1);
                FindCharacterOnScene(false).GetComponent<PlayerController>().SetPlayerInfo(map, 2);
                break;

            default:
                FindCharacterOnScene(true).GetComponent<PlayerController>().SetPlayerInfo(map, 1);
                break;
        }
    }

    void SpawnPlayers(int count)
    {
        switch (count)
        {
            case 1:
                FindCharacterOnScene(true).GetComponent<PlayerController>().SetPlayerInfo(map, 1);
                break;

            case 2:
                FindCharacterOnScene(true).GetComponent<PlayerController>().SetPlayerInfo(map, 1);
                FindCharacterOnScene(false).GetComponent<PlayerController>().SetPlayerInfo(map, 2);
                break;

            default:
                FindCharacterOnScene(true).GetComponent<PlayerController>().SetPlayerInfo(map, 1);
                break;
        }
    }

    GameObject FindCharacterOnScene(bool isFire)
    {
        if (isFire)
        {
            return GameObject.FindObjectOfType<FireMotor>().gameObject;
        }
        else
        {
            return GameObject.FindObjectOfType<IceMotor>().gameObject;
        }
    }
}
