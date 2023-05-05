using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] protected GameManagerScript gm;
    [SerializeField] protected Animator anim;

    public AttackScript[] attacks;
    public bool isPoisoned = false;
    public int poisonCount = 0;

    internal void Poisoned()
    {
        isPoisoned = true;
    }

    protected int currentAttack = -1;
    protected CharacterScript target;
    public bool isDead = false;
    int buffAmount = 0;
    
    public int maxHP = 100;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
        gm = GameObject.Find("Game Manager").GetComponent<GameManagerScript>();
    }

    public void GetBuff(int buffAmount)
    {
        this.buffAmount = buffAmount;
        Debug.Log(name + " buffed");
        anim.Play("player_attack");
    }
    public void set_target(CharacterScript target)
    {
        this.target = target;
    }

    public virtual void ChooseAttack()
    {
        currentAttack = new System.Random().Next(0, attacks.Length);
        Debug.Log(name + " chose attack " +  currentAttack);
    }

    public virtual void attack()
    {
        target.getHit(attacks[currentAttack].dmg + buffAmount);
        attacks[currentAttack].effect(target);
        buffAmount = 0;
        Debug.Log(name + " attacked " + target.name + " with " + attacks[currentAttack].name);
        anim.Play("player_attack");
    }

    public virtual void getHit(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0) Die();
        Debug.Log(name + " got hit for " + dmg);
        anim.Play("player_attack");
    }

    public void Heal(int healAmount)
    {
        if (isDead) return;
        currentHP += healAmount;
        if (currentHP > maxHP) currentHP = maxHP;
        Debug.Log(name + " healed for " + healAmount);
        anim.Play("player_attack");
    }

    public virtual void Die()
    {
        //die
        isDead = true;
        gameObject.SetActive(false);
        Debug.Log(name + " died");
        anim.Play("player_attack");
    }
    public void animationEnd()
    {
        gm.animation_ended(this);
    }
    public void poisonTick()
    {
        if (poisonCount > 0)
        {
            poisonCount--;
            currentHP--;
            if (currentHP <= 0) Die();
            Debug.Log(name + " took poison damage");
            anim.Play("player_attack");
        }
        else isPoisoned = false;
    }
}
