using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float rotationSpeed = 1.0f;

    private PlayerController controller;
    private Rigidbody rb;

    private Vector3 velocity = Vector3.zero;
    private Vector3 lookDirection = Vector3.zero;

	void Start ()
    {
        // Just a bunch o' null checks.
        controller = GetComponent<PlayerController>();
        if (controller == null)
        {
            Debug.LogError("No PlayerController attached to " + gameObject.name);
        }

        // Starts the player looking forward.
        lookDirection = transform.forward;
	}


    public void AddMovement(Vector2 input, Vector2 lookInput)
    {
        // Adds velocity and look direction into vector 3's.
        velocity = new Vector3(input.x, 0, input.y);
        lookDirection = new Vector3(lookInput.x, 0, lookInput.y);

        // Multiplies velocity by movespeed and time.
        velocity *= (moveSpeed * Time.deltaTime);
    }

    public virtual void Evade()
    {
        // Will be overridden.
        return;
    }

    private void FixedUpdate()
    {
        // If the player is applying input to the right stick.
        if (lookDirection != Vector3.zero)
        {
            // face the direction that was passed in through player controller.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), rotationSpeed * Time.deltaTime);
        }

        // If the player is applying input to the left stick.
        if (velocity != Vector3.zero)
        {
            // Add the velocity to the position of the object.
            transform.position += velocity;
        }

        // Sets the velocity magnitude as the speed variable for the character animator.
        controller.anim.SetFloat("velocity", velocity.magnitude);
        // Sets the angle between transform.forward and the velocity as the direction to strafe.
        controller.anim.SetFloat("locomotionDir", Vector3.Angle(transform.forward, velocity));
        Debug.Log(velocity.magnitude);
    }
}
