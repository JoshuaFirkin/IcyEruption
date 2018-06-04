using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttack : MonoBehaviour
{
    public abstract void ActionOne();
    public abstract void ActionTwo();
    public abstract void ActionThree();

    protected virtual List<iKillable> CheckHitBox(Vector3 pos, Vector3 size)
    {
        List<iKillable> killables = new List<iKillable>();
        Collider[] cols = Physics.OverlapBox(pos, size);

        foreach (Collider col in cols)
        {
            iKillable k = col.gameObject.GetComponentInParent<iKillable>();
            if (k != null)
            {
                killables.Add(k);
            }
        }

        Debug.Log("Hit " + killables.Count + " iKillables.");
        return killables;
    }

    protected virtual List<iKillable> CheckHitSphere(Vector3 pos, float radius)
    {
        List<iKillable> killables = new List<iKillable>();
        Collider[] cols = Physics.OverlapSphere(pos, radius);

        foreach (Collider col in cols)
        {
            iKillable k = col.gameObject.GetComponentInParent<iKillable>();
            if (k != null)
            {
                killables.Add(k);
            }
        }

        Debug.Log("Hit " + killables.Count + " iKillables.");
        return killables;
    }
}
