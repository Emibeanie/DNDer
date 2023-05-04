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
