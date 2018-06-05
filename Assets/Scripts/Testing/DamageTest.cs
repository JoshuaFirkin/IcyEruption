using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour
{
    float secs = 1.0f;

    void OnTriggerStay(Collider other)
    {
        secs -= Time.deltaTime;

        if (secs <= 0)
        {
            secs = 1.0f;
            iKillable killable = other.GetComponentInParent<iKillable>();

            if (killable != null)
            {
                killable.ApplyDamage(1);
            }
        }
    }
}
