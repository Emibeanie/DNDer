using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class turnAction
{
    public enum ActionType { attack, playerAttack,playerDeffend, takeDamage,takePoisonDamage,getBuff,die}
    public ActionType actionType;
    public int amount;
    public float success;
    public CharacterScript acting;
    public string animation_name;

    public turnAction(ActionType actionType, CharacterScript acting, string animation_name, int amount = 0,float success = 0f)
    {
        this.actionType = actionType;
        this.amount = amount;
        this.acting = acting;
        this.animation_name = animation_name;
        this.success = success;
    }
    public void CallAction()
    {
        acting.anim.SetTrigger("attack");
        //acting.anim.Play(animation_name);
        switch (actionType)
        {
            case ActionType.attack:
                acting.attack();
                Debug.Log(acting.name + " attacked");
                break;
            case ActionType.playerAttack:
                ((PlayerScript)acting).PlayerAttack(success);
                Debug.Log("Player Attacked");
                break;
            case ActionType.playerDeffend:
                ((PlayerScript)acting).PlayerDefend(success);
                Debug.Log("Player Defend");
                break;
            case ActionType.takeDamage:
                acting.getHit(amount);
                Debug.Log(acting.name + " hit for " + amount);
                break;
            case ActionType.takePoisonDamage:
                acting.poisonTick();
                Debug.Log(acting.name + " took 1 poison damange");
                break;
            case ActionType.getBuff:
                acting.GetBuff(amount);
                Debug.Log(acting.name + " buffed for " + amount);
                break;
            case ActionType.die:
                acting.Die();
                Debug.Log(acting.name + " Died");
                break;
        }
    }
}
