using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrkonikaSpacialAttack : AttackScript
{
    public AudioSource source;
    public AudioClip clip;
    public override void effect(CharacterScript target)
    {
        source.PlayOneShot(source.clip);
        GameManagerScript gm = GameObject.FindAnyObjectByType<GameManagerScript>();
        foreach (EnemyScript enemy in gm.enemies)
        {
            gm.turnActions.Insert(0,new turnAction(turnAction.ActionType.takeDamage, enemy, "hit", 4));
        }
        base.effect(target);
    }
}
