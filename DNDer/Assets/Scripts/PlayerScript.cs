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
        int dmg = (int)(maxAtt * success) + buffAmount;
        gm.turnActions.Insert(0,
            new turnAction(turnAction.ActionType.takeDamage, target, "attack",
            dmg));
        if (gm.lover.lastDamage > -1)
        {
            if (dmg > gm.lover.lastDamage)
                gm.lover.CheckTriggers(AffectionTrigger.Trigger.attack_for_more);
            else if (dmg < gm.lover.lastDamage)
                gm.lover.CheckTriggers(AffectionTrigger.Trigger.attack_for_less);
        }
        buffAmount = 0;
    }
    public void PlayerDefend(float success)
    {
        def_points = (int)(maxDef * success);
    }

    public override void getHit(int dmg)
    {
        dmg -= def_points;
        if (dmg > 0) gm.lover.CheckTriggers(AffectionTrigger.Trigger.get_hit);
        def_points = 0;
        base.getHit(dmg);
    }
}
