using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] protected GameManagerScript gm;
    [SerializeField] protected Animator anim;

    public AttackScript[] attacks;
    protected int currentAttack = -1;
    protected CharacterScript target;
    public bool isDead = false;
    int buffAmount = 0;
    
    [SerializeField] int maxHP = 100;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void GetBuff(int buffAmount)
    {
        this.buffAmount = buffAmount;
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
    public void animationEnd()
    {
        gm.animation_ended(this);
    }
}
