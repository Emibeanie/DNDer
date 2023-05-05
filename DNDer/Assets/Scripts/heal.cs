using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : AttackScript
{
    public override void effect(CharacterScript target)
    {
        Debug.Log("heal");
        base.effect(target);
    }
}
