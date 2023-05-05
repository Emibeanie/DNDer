using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] LoverScript lover;
    [SerializeField] FightScript[] fights;
    [SerializeField] Transform[] enemyPos;
    [SerializeField] GameObject chooseUI;
    [SerializeField] GameObject strBarUI;

    EnemyScript[] enemies;

    int currentFight = -1;
    bool choseAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        chooseUI.SetActive(false);
        strBarUI.SetActive(false);
        SetPlayer();
        Next_fight();
        //SetEnemy();
    }

    //private void SetEnemy()
    //{
    //    player.enemy = enemy;
    //    lover.enemy = enemy;
    //    enemy.player = player;
    //}

    private void SetPlayer()
    {
        lover.player = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Next_fight()
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
        Begin_fight();
    }
    private void Begin_fight()
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
        StrBar();
    }
    public void StrBar()
    {
        //read bar %
        //change affection if relevant
        //text based on success% and affection
        PlayActions();
    }

    public void PlayActions()
    {
        //if attack was chosen, attack first enemy, if enemy dies destroy enemy and advance enemy2
        //companion action
        //enemy1 action (if def was chosen proc def), if relevant change affection
        //enemy2 action (if def was chosen proc def)
    }

    private void Win()
    {

    }
}
