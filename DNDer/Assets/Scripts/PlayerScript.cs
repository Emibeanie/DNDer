using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public int atk = 10;
    public EnemyScript enemy;
    public int def = 0;

    [SerializeField] private int maxHP = 100;
    [SerializeField] private int crit = 3;

    private int currentHP;
    private int atkSuccess;
    private int defSuccess;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void Attack(int hit)
    {
        atkSuccess = hit;
        switch (atkSuccess)
        {
            case 0: //Attack failed
                // Trigger a funny failing animation
                // If relevant, increase or reduce lovers's affection
                break;
            case 1: //Attack succeeded
                // Trigger an attack animation, damage enemy
                // If relevant, increase or reduce lovers's affection
                enemy.EnemyTakesDamage(atk);
                break;
            case 2: //CRIT Attack
                // Trigger a special attack animation, damage enemy
                // If relevant, increase or reduce lovers's affection
                enemy.EnemyTakesDamage(atk * crit);
                break;
            default:
                break;
        }
    }

    public void Defend(int hit, int enemyDMG)
    {
        defSuccess = hit;
        switch (defSuccess)
        {
            case 0: //Defence failed
                    // Trigger a funny failing animation
                    // If relevant, increase or reduce lovers's affection
                TakeDamage(enemyDMG);
                break;
            case 1: //Defence succeeded
                // Trigger a defence animation, reduce player's HP by currentHP -= (enemyDMG + defValue)
                // If relevant, increase or reduce lovers's affection
                TakeDamage(enemyDMG);
                break;
            case 2: //Defence succeeded completely
                // Trigger a defence animation, don't reduce player's HP
                // If relevant, increase or reduce lovers's affection
                break;
            default:
                break;
        }
    }

    public int TakeDamage(int dmg)
    {
        int total = dmg - def;
        if(total > 0) currentHP -= total; //if def>damage do nothing
        if (currentHP < 0)
        {
            currentHP = 0;
        }
        return total;
    }

    public void Heal(int healAmount) //Panacea can heal player
    {
        currentHP += healAmount;
        if (currentHP > maxHP) currentHP = maxHP;
    }
}
