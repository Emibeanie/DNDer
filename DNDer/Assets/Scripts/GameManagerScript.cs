using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] LoverScript lover;

    [SerializeField] FightScript[] fights;
    int current_fight = -1;
    EnemyScript[] enemies;
    [SerializeField] Transform[] enemy_pos;
    [SerializeField] GameObject chooseUI;
    [SerializeField] GameObject strBarUI;

    bool chose_attack = true;

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
        current_fight++;
        if (fights.Length < current_fight + 1)
        {
            Win();
            return;
        }
        FightScript fight = fights[current_fight];
        enemies = new EnemyScript[fight.enemies.Length];
        for (int i = 0; i < fight.enemies.Length; i++)
        {
            enemies[i] = Instantiate(fight.enemies[i]);
            enemies[i].transform.position = enemy_pos[i].position;
        }
        Begin_fight();
    }
    private void Begin_fight()
    {
        setup();
    }

    public void setup()
    {
        //choose random attack for each enemy and play setup animation
        foreach (var enemy in enemies)
        {
            enemy.currentAttack = new System.Random().Next(0, enemy.attacks.Length);
            //play setup animation
        }
        choose_menu();
    }

    public void choose_menu()
    {
        chooseUI.SetActive(true);
    }

    public void choose_action(bool decision)
    {
        chose_attack = decision;
        chooseUI.SetActive(false);
        strBarUI.SetActive(true);
    }
    public void strBar()
    {

    }

    public void playActions()
    {

    }

    private void Win()
    {

    }
}
