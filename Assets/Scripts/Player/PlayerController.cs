using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    [SerializeField] private Camera cam;

    private PlayerMotor motor;
    private bool allowInput = true;

    void Start()
    {
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
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        Vector2 lookInput = new Vector2(Input.GetAxis("LookHorizontal"), Input.GetAxis("LookVertical")).normalized;

        // Adds movement to the velocity of the motor.
        motor.AddMovement(input, lookInput);

        // Allows evade to happen.
        if (Input.GetButtonDown("Evade"))
        {
            motor.Evade();
        }
    }
}
