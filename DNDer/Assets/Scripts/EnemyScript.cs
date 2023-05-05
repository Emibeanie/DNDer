using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public PlayerScript player;
    public AttackScript[] attacks;
    public int currentAttack = 0;
    
    [SerializeField] int dmg;

    private int maxHP = 100;
    private int currentHP;

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

    private int EnemyDealDamage(int damage, PlayerScript player)
    {
        //Start attack animation
        return player.TakeDamage(dmg); //????
    }

    public int EnemyAttack(PlayerScript player)
    {
        return EnemyDealDamage(dmg, player);
    }

    public int EnemySpecialAttack(PlayerScript player)
    {
        //Start "special" animation
        return EnemyDealDamage(dmg*2, player);
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
}
