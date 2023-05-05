using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] GameManagerScript gm;
    [SerializeField] Animator anim;

    public AttackScript[] attacks;
    int currentAttack = -1;
    int buffAmount = 0;
    protected CharacterScript target;

    internal void GetBuff(int buffAmount)
    {
        this.buffAmount += buffAmount;
    }

    public bool isDead = false;
    
    [SerializeField] int maxHP = 100;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void set_target(CharacterScript target)
    {
        this.target = target;
    }

    public virtual void ChooseAttack()
    {
        currentAttack = new System.Random().Next(0, attacks.Length);
    }

    public virtual void attack()
    {
        target.getHit(attacks[currentAttack].dmg + buffAmount);
        attacks[currentAttack].effect(target);
        buffAmount = 0;
    }

    public virtual void getHit(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0) Die();
    }

    public void Heal(int healAmount)
    {
        if (isDead) return;
        currentHP += healAmount;
        if (currentHP > maxHP) currentHP = maxHP;
    }

    public virtual void Die()
    {
        //die
        isDead = true;
        gameObject.SetActive(false);
    }
}
