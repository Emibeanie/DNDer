using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPlayerScript : AttackScript
{
    [SerializeField] int buffAmount;
    public override void effect(CharacterScript target)
    {
        Debug.Log("heal");
        base.effect(target);
        target.GetBuff(buffAmount);
    }
}
