using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] LoverScript lover;
    [SerializeField] FightScript[] fights;
    [SerializeField] Transform[] enemyPos;
    [SerializeField] GameObject chooseUI;
    [SerializeField] GameObject strBarUI;
    [SerializeField] TextMeshProUGUI commentText;
  
    [SerializeField] float minPerfectHit;
    [SerializeField] float minSuccessfulHit;

    EnemyScript[] enemies;

    int currentFight = -1;
    bool choseAttack = true;
    float barScore = 0;

    int actionIndex = -1;
    bool actionMode = false;

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
            enemies[i].set_target(player);
        }
        player.set_target(enemies[0]);
        lover.set_target(enemies[0]);
        BeginFight();
    }
    private void BeginFight()
    {
        Setup();
    }

    public void Setup()
    {
        //choose random attack for each enemy and play setup animation
        foreach (var enemy in enemies)
        {
            enemy.ChooseAttack();
            enemy.SetupAnimation();
        }
        lover.ChooseAttack();
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
        if (barPos > minPerfectHit) barPos = 1;
        else if (barPos < minSuccessfulHit) barPos = 0;
        barScore = barPos;
        PlayActions();
    }

    public void PlayActions()
    {
<<<<<<< HEAD
        actionIndex++;
        switch (actionIndex)
=======
        //if attack was chosen, attack first enemy, if enemy dies destroy enemy and advance enemy2
        if(choseAttack && !enemies[0].IsEnemyDead()) enemies[0].EnemyTakesDamage(player.atk);
        if (!enemies[0].IsEnemyDead()) AdvanceEnemyArray();
        //companion action
        lover.SpecialMove();
        //enemy1 action (if def was chosen proc def), if relevant change affection
        foreach (var enemy in enemies)
>>>>>>> origin/Yoav
        {
            case 0:
                if (choseAttack) player.PlayerAttack(barScore);
                else player.PlayerDefend(barScore);
                break;
            case 1:
                lover.attack();
                break;
            case 2:
                enemies[0].attack();
                break;
            case 3:
                if(enemies.Length > 1) enemies[1].attack();
                break;
            case 4:
                actionIndex = -1;
                EffectsActions();
                break;
        }
    }

<<<<<<< HEAD
    public void EffectsActions()
    {

    }

=======
>>>>>>> origin/Yoav
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

    public bool isAttacking()
    {
        return choseAttack;
    }

    public void animation_ended(CharacterScript character)
    {
        if (actionMode) PlayActions();
    }
}
