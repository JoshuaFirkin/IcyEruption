using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMotor : PlayerMotor
{
    [SerializeField] private float dodgeDistance = 3.0f;

    public override void Evade()
    {
        base.Evade();

        if (isEvading)
        {
            return;
        }

        StartCoroutine(CarryOutEvade());
    }

    private IEnumerator CarryOutEvade()
    {
        controller.allowInput = false;
        isEvading = true;

        lookDirection = velocity;
        transform.rotation = Quaternion.LookRotation(lookDirection);

        controller.anim.SetTrigger("evade");

        AnimatorStateInfo stateInfo = controller.anim.GetCurrentAnimatorStateInfo(0);
        float secs = stateInfo.length;

        while (secs > 0)
        {
            secs -= Time.deltaTime;
            velocity = transform.forward * (dodgeDistance / 10);

            yield return null;
        }


        controller.allowInput = true;
        isEvading = false;
    }
}
