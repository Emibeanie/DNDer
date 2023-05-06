using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenSpecialAttack : AttackScript
{
    [SerializeField] int buffAmount;
    public AudioSource source;
    public AudioClip clip;
    public override void effect(CharacterScript target)
    {
        source.PlayOneShot(source.clip);
        GameManagerScript gm = GameObject.FindAnyObjectByType<GameManagerScript>();
        foreach (EnemyScript enemy in gm.enemies)
        {
            gm.turnActions.Insert(0, new turnAction(turnAction.ActionType.getBuff, enemy, "hit", buffAmount));
        }
        gm.turnActions.Insert(0, new turnAction(turnAction.ActionType.getBuff, gm.player, "hit", buffAmount * 2));
        
        base.effect(target);
    }
}
