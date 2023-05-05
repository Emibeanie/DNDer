<<<<<<< HEAD
<<<<<<< HEAD
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
=======
=======
>>>>>>> parent of cd952df (Merge branch 'Sharron' into emily)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoverScript : MonoBehaviour
{
    public PlayerScript player;
    public EnemyScript enemy;

    public int Affection
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        Affection = 0;
    }

    public void SpecialMove()
    {
        // depends on lover chosen
        //DealDamage(0);
    }

    private void DealDamage(int dmg)
    {
        enemy.EnemyTakesDamage(dmg);
    }
}
<<<<<<< HEAD
>>>>>>> parent of cd952df (Merge branch 'Sharron' into emily)
=======
>>>>>>> parent of cd952df (Merge branch 'Sharron' into emily)
