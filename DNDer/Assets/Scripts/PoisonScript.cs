using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonScript : AttackScript
{
    [SerializeField] int turns = 5;
    public override void effect(CharacterScript target)
    {
        Debug.Log("poison");
        base.effect(target);
        target.Poisoned();
        target.poisonCount = turns;
    }
}
