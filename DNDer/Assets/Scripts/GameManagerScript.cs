using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] LoverScript lover;
    [SerializeField] FightScript[] fights;
    [SerializeField] Transform[] enemyPos;
    [SerializeField] GameObject chooseUI;
    [SerializeField] GameObject strBarUI;
    [SerializeField] TextMeshProUGUI commentText;
    [SerializeField] float maxPerfectHit;
    [SerializeField] float maxSuccessfulHit;

    EnemyScript[] enemies;

    int currentFight = -1;
    bool choseAttack = true;
    int dmg;

    // Start is called before the first frame update
    void Start()
    {
        chooseUI.SetActive(false);
        strBarUI.SetActive(false);
        SetPlayer();
        NextFight();
    }

    private void SetPlayer()
    {
        lover.player = player;
    }

    private void NextFight()
    {
        currentFight++;
        if (fights.Length < currentFight + 1)
        {
            Win();
            return;
        }
        FightScript fight = fights[currentFight];
        enemies = new EnemyScript[fight.enemies.Length];
        for (int i = 0; i < fight.enemies.Length; i++)
        {
            enemies[i] = Instantiate(fight.enemies[i]);
            enemies[i].transform.position = enemyPos[i].position;
        }
        BeginFight();
    }
    private void BeginFight()
    {
        SetupFight();
    }

    public void SetupFight()
    {
        //choose random attack for each enemy and play setup animation
        foreach (var enemy in enemies)
        {
            enemy.currentAttack = new System.Random().Next(0, enemy.attacks.Length);
            //play setup animation
        }
        ChoiceMenu();
    }

    public void ChoiceMenu()
    {
        chooseUI.SetActive(true);
    }

    public void ChooseAction(bool decision)
    {
        choseAttack = decision;
        chooseUI.SetActive(false);
        strBarUI.SetActive(true);
    }
    public void StrBar(float barPos)
    {
        //read bar %
        //need to change how player.Attack and Defend work
        if(barPos < maxPerfectHit)
        {
            //perfect
            if (choseAttack)
            {
                player.atk = 10;
                TypeCommentText("Perfect Hit!");
            }
            else
            {
                //player.Defend(2, 0);
                player.def += 100;
                TypeCommentText("Perfect Defence!");
            }
        }
        else if(barPos < maxSuccessfulHit)
        {
            //not perfect
            if (choseAttack)
            {
                player.atk = 3;
                TypeCommentText("Successful Hit!");
            }
            else
            {
                player.def += 5;
                //player.Defend(2, 0);
                TypeCommentText("Successful Defence!");
            }
        }
        else
        {
            //failed
            if (choseAttack)
            {
                player.atk = 0;
            }
            else
            {
                //player.Defend(2, 0);
            }
            TypeCommentText("You are a failure in the eyes of your ancestors");
        }
        //change affection if relevant
        //text based on success% and affection
        PlayActions();
    }

    public void PlayActions()
    {
        //if attack was chosen, attack first enemy, if enemy dies destroy enemy and advance enemy2
        if(choseAttack && !enemies[0].IsEnemyDead()) enemies[0].EnemyTakesDamage(player.atk);
        if (!enemies[0].IsEnemyDead()) AdvanceEnemyArray();
        //companion action
        lover.SpecialMove();
        //enemy1 action (if def was chosen proc def), if relevant change affection
        foreach (var enemy in enemies)
        {
            if (enemy.IsEnemyDead()) continue;
            if (enemy.currentAttack == 0) dmg = enemy.EnemyAttack(player);
            else if (enemy.currentAttack == enemy.attacks.Length) dmg = enemy.EnemySpecialAttack(player);
            if (dmg < 0) dmg = 0;
            TypeCommentText($"Took {dmg} damage!");
        }
        player.atk = 0;
        player.def = 0;
    }

    public void TypeCommentText(string txt)
    {
        commentText.text = txt;
    }

    private void AdvanceEnemyArray()
    {
        for (int i = 0; i < enemies.Length - 1; i++)
        {
            enemies[i] = enemies[i + 1];
        }
        if (enemies.Length > 1)
        {
            enemies[enemies.Length - 1] = null;
        }
    }

    private void Win()
    {

    }
}
