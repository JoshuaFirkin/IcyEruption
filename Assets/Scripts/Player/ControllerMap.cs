using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMap
{
    public bool mapAssigned = false;

    public string horAxis;
    public string vertAxis;
    public string horLook;
    public string vertLook;
    public string actionOne;
    public string actionTwo;
    public string actionThree;
    public string evade;

    public ControllerMap(RuntimePlatform platform, int playerNumber)
    {
        ChangeControllerMap(platform, playerNumber);
    }

    void ChangeControllerMap(RuntimePlatform platform, int playerNumber)
    {
        mapAssigned = true;

        switch (platform)
        {
            case RuntimePlatform.PS4:
                horAxis = "Horizontal_PS4";
                vertAxis = "Vertical_PS4";
                horLook = "LookHorizontal_PS4";
                vertLook = "LookVertical_PS4";
                actionOne = "ActionOne_PS4";
                actionTwo = "ActionTwo_PS4";
                actionThree = "ActionThree_PS4";
                evade = "Evade_PS4";
                break;


            case RuntimePlatform.XboxOne:
                horAxis = "Horizontal_XBONE";
                vertAxis = "Vertical_XBONE";
                horLook = "LookHorizontal_XBONE";
                vertLook = "LookVertical_XBONE";
                actionOne = "ActionOne_XBONE";
                actionTwo = "ActionTwo_XBONE";
                actionThree = "ActionThree_XBONE";
                evade = "Evade_XBONE";
                break;


            default:
                horAxis = "Horizontal_XBONE";
                vertAxis = "Vertical_XBONE";
                horLook = "LookHorizontal_XBONE";
                vertLook = "LookVertical_XBONE";
                actionOne = "ActionOne_XBONE";
                actionTwo = "ActionTwo_XBONE";
                actionThree = "ActionThree_XBONE";
                evade = "Evade_XBONE";
                break;
        }

        horAxis += ("_P" + playerNumber);
        vertAxis += ("_P" + playerNumber);
        horLook += ("_P" + playerNumber);
        vertLook += ("_P" + playerNumber);
        actionOne += ("_P" + playerNumber);
        actionTwo += ("_P" + playerNumber);
        actionThree += ("_P" + playerNumber);
        evade += ("_P" + playerNumber);
    }
}

