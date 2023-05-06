using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] protected GameManagerScript gm;
    [SerializeField] public Animator anim;

    public List<AttackScript> attacks;
    public bool isPoisoned = false;
    public int poisonCount = 0;

    internal void Poisoned()
    {
        isPoisoned = true;
    }

    protected int currentAttack = -1;
    protected CharacterScript target;
    public bool isDead = false;
    protected int buffAmount = 0;
    
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
        gm.turnActions.Insert(0,new turnAction(turnAction.ActionType.getBuff, this, "player_attack"));
    }
    public void set_target(CharacterScript target)
    {
        this.target = target;
    }

    public virtual void ChooseAttack()
    {
        currentAttack = new System.Random().Next(0, attacks.Count);
    }
    //public virtual void AssignAttack()
    //{
    //    gm.turnActions.Enqueue(new turnAction(turnAction.ActionType.attack, this, "player_attack"));
    //}
    //public virtual void AssignTakeDamage()
    //{

    //}
    public virtual void attack()
    {
        gm.turnActions.Insert(0,
            new turnAction(turnAction.ActionType.takeDamage, target, "player_attack", 
            attacks[currentAttack].dmg + buffAmount));
        attacks[currentAttack].effect(target);
        buffAmount = 0;
    }

    public virtual void getHit(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
            gm.turnActions.Insert(0,new turnAction(turnAction.ActionType.die, this, "player_attack"));
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
    public void poisonTick()
    {
        if (poisonCount > 0)
        {
            poisonCount--;
            currentHP--;
            if (currentHP <= 0)
                gm.turnActions.Insert(0, new turnAction(turnAction.ActionType.die, this, "player_attack"));
        }
        else isPoisoned = false;
    }
}
