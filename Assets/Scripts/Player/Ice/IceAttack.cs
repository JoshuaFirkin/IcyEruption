using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAttack : PlayerAttack
{

    public override void ActionOne()
    {
        Debug.Log("Quick Attack!");
    }

    public override void ActionTwo()
    {
        Debug.Log("Strong Attack!");
    }

    public override void ActionThree()
    {
        Debug.Log("AOE Attack!");
    }
}
