using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static float moveSpeed = 10.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.forward * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IceMotor>() || other.GetComponent<FireMotor>())
        {
            return;
        }

        iKillable killable = other.GetComponent<iKillable>();
        if (killable != null)
        {
            killable.ApplyDamage(1);
        }
    }
}
