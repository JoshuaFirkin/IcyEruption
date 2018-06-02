using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [HideInInspector] public Animator anim;
    [HideInInspector] public bool allowInput = true;

    [SerializeField] private Camera cam;

    private ControllerMap ctrlMap;
    private PlayerMotor motor;

    void Start()
    {
        ctrlMap = new ControllerMap(RuntimePlatform.XboxOne, 1);

        // Just a bunch o' null checks.
        if (cam == null)
        {
            Debug.LogWarning("No camera attached to" + gameObject);
        }

        motor = GetComponent<PlayerMotor>();
        if (motor == null)
        {
            Debug.LogError("No PlayerMotor attached to " + gameObject.name);
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
        if (!allowInput)
        {
            return;
        }

        // Gets the input of the left stick and right stick and stores it in Vector2's.
        Vector2 input = new Vector2(Input.GetAxis(ctrlMap.horAxis), Input.GetAxis(ctrlMap.vertAxis)).normalized;
        Vector2 lookInput = new Vector2(Input.GetAxis(ctrlMap.horLook), Input.GetAxis(ctrlMap.vertLook)).normalized;

        // Adds movement to the velocity of the motor.
        motor.AddMovement(input, lookInput);

        // Allows evade to happen.
        if (Input.GetButtonDown(ctrlMap.evade))
        {
            motor.Evade();
        }
        else if (Input.GetButtonDown(ctrlMap.actionOne))
        {

        }
        else if (Input.GetButtonDown(ctrlMap.actionTwo))
        {

        }
        else if (Input.GetButtonDown(ctrlMap.actionThree))
        {

        }
    }
}
