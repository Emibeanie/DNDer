using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonScript : AttackScript
{
    public override void effect(CharacterScript target)
    {
        Debug.Log("poison");
        base.effect(target);
        target.Poisoned();
    }
}
