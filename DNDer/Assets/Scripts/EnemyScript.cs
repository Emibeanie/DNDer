using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int dmg;

    private int maxHP;
    private int currentHP;
    
    private PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        SetEnemyMaxHP();
        currentHP = maxHP;
    }

    private void SetEnemyMaxHP()
    {
        //maxHP = 
    }

    private void EnemyDealDamage()
    {
        player.TakeDamage(dmg); //????
    }

    public void EnemyTakesDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP < 0) currentHP = 0;
        if (IsEnemyDead()) EnemyDies();
    }

    private void EnemyDies()
    {
        Destroy(gameObject);
        // if relevant, increase lover's affection
    }

    public bool IsEnemyDead()
    {
        return currentHP <= 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
