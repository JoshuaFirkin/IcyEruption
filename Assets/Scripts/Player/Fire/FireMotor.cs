using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMotor : PlayerMotor
{
    [SerializeField] private AnimationClip evadeAnim;
    [SerializeField] private float dodgeDistance = 3.0f;


    public override void Evade()
    {
        base.Evade();
        StartCoroutine(CarryOutEvade());
    }

    private IEnumerator CarryOutEvade()
    {
        controller.allowInput = false;

        lookDirection = velocity;
        transform.rotation = Quaternion.LookRotation(lookDirection);

        controller.anim.SetTrigger("evade");

        AnimatorStateInfo stateInfo = controller.anim.GetCurrentAnimatorStateInfo(0);
        float secs = stateInfo.length;

        yield return new WaitForSeconds(secs);

        controller.allowInput = true;
    }
}
