using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class LoverScript : CharacterScript
{
    public PlayerScript player;

    public AttackScript specialAttackPrefab;

    public int lastDamage = -1;
    public int affection = 0;
    public int maxAffection = 10;
    [SerializeField] public AffectionTrigger[] triggers;
    [SerializeField] public string[] likeText;
    int likeTextIndex = -1;
    [SerializeField] public string[] dislikeText;
    int dislikeTextIndex = -1;

    [SerializeField] int affForSpecial = 7;
    public void AddAffection(int addAff)
    {
        affection += addAff;
        if (affection > maxAffection) affection = maxAffection;
        anim.SetTrigger("love");
        likeTextIndex++;
        if (likeTextIndex >= likeText.Length) likeTextIndex = 0;
        gm.dialogueBox.Show(likeText[likeTextIndex]);

        if (affection > affForSpecial - 1) attacks.Add(specialAttackPrefab);
    }
    public void ReduceAffection(int redAff)
    {
        if (affection == affForSpecial) attacks.Remove(specialAttackPrefab);
        affection -= redAff;
        if (affection < 0) affection = 0;
        anim.SetTrigger("bad_love");
        dislikeTextIndex++;
        if (dislikeTextIndex >= dislikeText.Length) dislikeTextIndex = 0;
        gm.dialogueBox.Show(dislikeText[dislikeTextIndex]);
    }

    public override void attack()
    {
        lastDamage = attacks[currentAttack].dmg + buffAmount;
        base.attack();
    }
    public void CheckTriggers(AffectionTrigger.Trigger fired)
    {
        int result = 0;
        foreach(AffectionTrigger trigger in triggers)
        {
            result = trigger.Check(fired);
            if (result != 0)
            {
                if (result < 0) ReduceAffection(1);
                else AddAffection(1);
                return;
            }
        }
    }


}
