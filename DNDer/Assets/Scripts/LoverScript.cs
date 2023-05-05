using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoverScript : MonoBehaviour
{
    public PlayerScript player;
    public EnemyScript enemy;

    [SerializeField] GameManagerScript gm;
    [SerializeField] GameObject[] moves;

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
        int chosenMove = new System.Random().Next(0, moves.Length);
        DoSpecialMove(moves[chosenMove]);
        // depends on lover chosen
        //DealDamage(0);
    }

    private void DoSpecialMove(GameObject move)
    {
        if (Affection < Array.IndexOf(moves, move))
        {
            gm.TypeCommentText("Your companion isn't interested in helping you");
            return;
        }
    }

    private void DealDamage(int dmg)
    {
        enemy.EnemyTakesDamage(dmg);
    }
}
