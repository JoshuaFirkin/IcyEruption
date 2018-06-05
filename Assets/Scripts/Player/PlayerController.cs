using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    [HideInInspector] public bool allowInput = true;

    private ControllerMap ctrlMap;
    private int playerID;
    private PlayerMotor motor;
    private PlayerAttack attack;

    void Start()
    {
        // Just a bunch of null checks.
        motor = GetComponent<PlayerMotor>();
        if (motor == null)
        {
            Debug.LogError("No PlayerMotor attached to " + gameObject.name);
        }

        attack = GetComponent<PlayerAttack>();
        if (attack == null)
        {
            Debug.LogError("No PlayerAttack script attached to " + gameObject.name);
        }

        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("No Animator attached to " + gameObject.name);
        }
    }

    void Update()
    {
        // This is so that the input can be disabled if we need it to be.
        if (!allowInput || ctrlMap == null)
        {
            return;
        }

        CheckInput();
    }

    void CheckInput()
    {
        // Gets the input of the left stick and right stick and stores it in Vector2's.
        Vector2 input = new Vector2(Input.GetAxis(ctrlMap.horAxis), Input.GetAxis(ctrlMap.vertAxis)).normalized;
        Vector2 lookInput = new Vector2(Input.GetAxis(ctrlMap.horLook), Input.GetAxis(ctrlMap.vertLook)).normalized;

        // Adds movement to the velocity of the motor.
        motor.AddMovement(input, lookInput);

        // Allows evade to happen.
        if (Input.GetAxis(ctrlMap.actionOne) > 0)
        {
            motor.Evade();
        }
        else if (Input.GetAxis(ctrlMap.actionOne) < 0)
        {
            attack.ActionOne();
        }
        else if (Input.GetButtonDown(ctrlMap.actionTwo))
        {
            attack.ActionTwo();
        }
        else if (Input.GetButtonDown(ctrlMap.actionThree))
        {
            attack.ActionThree();
        }
    }

    void AIControl()
    {
        return;
    }

    public void SetPlayerInfo(RuntimePlatform _platform, int _id)
    {
        playerID = _id;
        ctrlMap = new ControllerMap(_platform, _id);
        allowInput = true;

        Debug.Log("Player Assigned ID: " + playerID);
        Debug.Log("Player Controller Assigned As: " + _platform);
    }
}
