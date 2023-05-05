using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebAttackScript : AttackScript
{
    public override void effect(CharacterScript target)
    {
        Debug.Log("webbed");
        base.effect(target);
        //target.Web();
    }
}
