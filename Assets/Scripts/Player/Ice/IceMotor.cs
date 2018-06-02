using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMotor : PlayerMotor
{
    [SerializeField] private float dodgeDistance = 3.0f;

    public override void Evade()
    {
        base.Evade();
        StartCoroutine(CarryOutEvade());
    }

    private IEnumerator CarryOutEvade()
    {
        controller.allowInput = false;

        velocity = Vector3.zero;

        controller.anim.SetTrigger("evade");

        AnimatorStateInfo stateInfo = controller.anim.GetCurrentAnimatorStateInfo(0);
        float secs = stateInfo.length;

        while (secs > 0)
        {
            secs -= Time.deltaTime;

            yield return null;
        }

        controller.allowInput = true;
    }
}
