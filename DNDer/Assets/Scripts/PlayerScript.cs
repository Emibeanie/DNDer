using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlayerScript : CharacterScript
{
    [SerializeField] int maxAtt = 10;
    [SerializeField] int maxDef = 5;

    int def_points = 0;

    public void PlayerAttack(float success)
    {
        int dmg = (int)(maxAtt * success);
        gm.turnActions.Enqueue(
            new turnAction(turnAction.ActionType.takeDamage, target, "player_attack",
            dmg + buffAmount));
        buffAmount = 0;
    }
    public void PlayerDefend(float success)
    {
        def_points = (int)(maxDef * success);
    }

    public override void getHit(int dmg)
    {
        dmg -= def_points;
        def_points = 0;
        base.getHit(dmg);
    }
}
