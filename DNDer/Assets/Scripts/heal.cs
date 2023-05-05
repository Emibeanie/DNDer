using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : AttackScript
{
    [SerializeField] int healAmount;
    public override void effect(CharacterScript target)
    {
        Debug.Log("heal");
        base.effect(target);
        target.Heal(healAmount);
    }
}
