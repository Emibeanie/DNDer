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
            gm.turnActions.Insert(0, new turnAction(turnAction.ActionType.getBuff, enemy, "buff", buffAmount));
        }
<<<<<<< HEAD
        gm.turnActions.Insert(0, new turnAction(turnAction.ActionType.getBuff, gm.player, "hit", buffAmount * 2));
        
=======
        gm.turnActions.Insert(0, new turnAction(turnAction.ActionType.getBuff, gm.player, "buff", buffAmount * 2));

>>>>>>> fb0817323431dcad7808e1afed69a400d78dedd5
        base.effect(target);
    }
}
