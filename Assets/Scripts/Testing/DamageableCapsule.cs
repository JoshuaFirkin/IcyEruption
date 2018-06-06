using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCapsule : MonoBehaviour, iKillable
{
    [SerializeField] private int originalHP = 10;
    [SerializeField] private Color32 hitColour;

    private Color32 originalColour;
    private Material mat;
    private int hitPoints = 10;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        originalColour = mat.color;

        hitPoints = originalHP;
    }

    void iKillable.ApplyDamage(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Debug.Log("DED");
            Respawn();
        }
        else
        {
            Debug.Log("Took " + damage + " damage \n" + "HP is now " + hitPoints);
            StartCoroutine(ColourChange());
        }
    }

    IEnumerator ColourChange()
    {
        mat.color = hitColour;

        while (mat.color != originalColour)
        {
            mat.color = Color32.LerpUnclamped(mat.color, originalColour, Time.deltaTime * 2);
            yield return null;
        }
    }

    void Respawn()
    {
        hitPoints = originalHP;

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
    }
}
