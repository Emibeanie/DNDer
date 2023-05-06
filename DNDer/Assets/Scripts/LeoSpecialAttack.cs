using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeoSpecialAttack : AttackScript
{
    public override void effect(CharacterScript target)
    {
        GameManagerScript gm = GameObject.FindAnyObjectByType<GameManagerScript>();
        gm.turnActions.Insert(0, new turnAction(turnAction.ActionType.takeDamage, gm.player, "hit", 3));
        base.effect(target);
    }
}
