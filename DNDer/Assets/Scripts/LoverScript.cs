using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LoverScript : CharacterScript
{
    public PlayerScript player;

    public int affection = 0;
    public int maxAffection = 10;

    public void AddAffection(int addAff)
    {
        affection += addAff;
        if (affection > maxAffection) affection = maxAffection;
        Debug.Log(name + " affection went up");
        anim.Play("player_attack");
    }
    public void ReduceAffection(int redAff)
    {
        affection -= redAff;
        if (affection < 0) affection = 0;
        Debug.Log(name + " affection went down");
        anim.Play("player_attack");
    }


}
