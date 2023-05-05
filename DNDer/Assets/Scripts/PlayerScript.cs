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
        target.getHit(dmg);
        Debug.Log(name + " attacked " + target + " for " + dmg);
        anim.Play("player_attack");
    }
    public void PlayerDefend(float success)
    {
       def_points = (int)(maxDef * success);
       Debug.Log(name + " defended");
       anim.Play("player_attack");
    }

    public override void getHit(int dmg)
    {
        dmg -= def_points;
        def_points = 0;
        base.getHit(dmg);
    }
}
