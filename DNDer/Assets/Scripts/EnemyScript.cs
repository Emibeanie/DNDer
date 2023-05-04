using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int maxHP;
    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyMaxHP();
        currentHP = maxHP;
    }

    private void SetEnemyMaxHP()
    {
        
    }

    public void EnemyTakesDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP < 0) currentHP = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
