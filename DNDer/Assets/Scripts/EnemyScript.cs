<<<<<<< HEAD
<<<<<<< HEAD
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : CharacterScript
{
    public void SetupAnimation()
    {
        //play setup animation
        Debug.Log(name + "getting ready for attack");
        anim.Play("player_attack");
    }
}
=======
=======
>>>>>>> parent of cd952df (Merge branch 'Sharron' into emily)
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public PlayerScript player;

    [SerializeField] int dmg;

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
        //maxHP = 
    }

    private void EnemyDealDamage()
    {
        //Start attack animation
        player.TakeDamage(dmg); //????
    }

    private void EnemySpecialAttack()
    {
        //Start "special" animation
        EnemyDealDamage();
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
<<<<<<< HEAD
>>>>>>> parent of cd952df (Merge branch 'Sharron' into emily)
=======
>>>>>>> parent of cd952df (Merge branch 'Sharron' into emily)
