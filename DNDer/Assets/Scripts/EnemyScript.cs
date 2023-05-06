using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : CharacterScript
{
    public void SetupAnimation()
    {
        //play setup animation
        Debug.Log(name + "getting ready for attack");
        anim.Play("player_attack");
    }
}
