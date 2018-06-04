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
        canChangeLook = false;

        if (velocity != Vector3.zero)
        {
            lookDirection = velocity;
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        controller.anim.SetTrigger("evade");

        AnimatorStateInfo stateInfo = controller.anim.GetCurrentAnimatorStateInfo(0);
        // If the speed of the roll changes, this value needs to change.
        float secs = stateInfo.length * 0.46f;

        while (secs > 0)
        {
            secs -= Time.deltaTime;
            velocity = transform.forward * (dodgeDistance / 10);

            yield return null;
        }


        controller.allowInput = true;
        isEvading = false;

        yield return new WaitForSeconds(0.5f);
        canChangeLook = true;
    }
}
