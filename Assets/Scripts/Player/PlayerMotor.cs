using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public bool isEvading { get; protected set; }
    public bool canChangeLook { get; protected set; }

    [SerializeField] protected float moveSpeed = 1.0f;
    [SerializeField] protected float rotationSpeed = 1.0f;

    protected PlayerController controller;
    protected Rigidbody rb;

    protected Vector3 velocity = Vector3.zero;
    protected Vector3 lookDirection = Vector3.zero;

	protected virtual void Start ()
    {
        // Just a bunch o' null checks.
        controller = GetComponent<PlayerController>();
        if (controller == null)
        {
            Debug.LogError("No PlayerController attached to " + gameObject.name);
        }

        // Starts the player looking forward.
        lookDirection = transform.forward;
        canChangeLook = true;
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
        Debug.Log("Evading.");
    }

    public virtual void ActionOne()
    {
        // Will be overridden.
        Debug.Log("Performing Action One.");
    }

    public virtual void ActionTwo()
    {
        // Will be overridden.
        Debug.Log("Performing Action Two.");
    }

    public virtual void ActionThree()
    {
        // Will be overridden.
        Debug.Log("Performing Action Three.");
    }


    protected virtual void FixedUpdate()
    {
        if (isEvading)
        {
            transform.position += velocity;
            Debug.Log(velocity.magnitude);
            return;
        }

        // If the player is applying input to the right stick.
        if (lookDirection != Vector3.zero && canChangeLook)
        {
            // face the direction that was passed in through player controller.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), rotationSpeed * Time.deltaTime);
        }

        // If the player is applying input to the left stick.
        if (velocity != Vector3.zero)
        {
            // Add the velocity to the position of the object.
            transform.position += velocity;

            if (lookDirection == Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), rotationSpeed * Time.deltaTime);
            }
        }

        // Sets the velocity magnitude as the speed variable for the character animator.
        controller.anim.SetFloat("velocity", velocity.magnitude);

        float angle = Vector3.Angle(transform.forward, velocity);
        Vector3 cross = Vector3.Cross(transform.forward, velocity);
        if (cross.y < 0)
        {
            angle = 360 - angle;
        }
        // Sets the angle between transform.forward and the velocity as the direction to strafe.
        controller.anim.SetFloat("locomotionDir", angle);
    }
}