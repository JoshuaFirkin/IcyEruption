using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI chosenText;
    public int charID = 1;

    public void Navigate()
    {
        if (charID == 1)
        {
            charID = 2;
            chosenText.text = "Ice";
        }
        else
        {
            charID = 1;
            chosenText.text = "Fire";
        }
    }

    public void ChooseCharacter()
    {
    }
}
