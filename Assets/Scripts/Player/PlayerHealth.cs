using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, iKillable
{
    public bool isDead { get; private set; }

    [SerializeField] private int originalHitPoints = 3;
    [SerializeField] private GameObject[] extras;

    private PlayerController controller;
    private int hitPointsRemaining;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        if (controller == null)
        {
            Debug.LogError("No Controller Attached to " + gameObject.name);
        }

        hitPointsRemaining = originalHitPoints;

    }


    void iKillable.ApplyDamage(int damage)
    {
        hitPointsRemaining -= damage;

        if (hitPointsRemaining <= 0)
        {
            CharacterDeath();
        }
    }


    void CharacterDeath()
    {
        isDead = true;

        controller.allowInput = false;
        controller.anim.SetTrigger("death");

        foreach (GameObject obj in extras)
        {
            obj.SetActive(false);
        }
    }
}
