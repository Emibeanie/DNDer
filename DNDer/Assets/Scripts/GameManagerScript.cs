using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

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
    CharacterScript[] allCharacters;

    int currentFight = -1;
    bool choseAttack = true;
    float barScore = 0;

    int actionIndex = -1;
    bool actionMode = false;

    bool effectsMode = false;

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
        allCharacters = new CharacterScript[fight.enemies.Length + 2];
        allCharacters[0] = player;
        allCharacters[1] = lover;
        for (int i = 0; i < fight.enemies.Length; i++)
        {
            enemies[i] = Instantiate(fight.enemies[i]);
            enemies[i].transform.position = enemyPos[i].position;
            enemies[i].set_target(player);
            allCharacters[i+2] = enemies[i];
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
        strBarUI.SetActive(false);
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
        actionMode = true;
        PlayActions();
    }

    public void PlayActions()
    {
        actionIndex++;
        switch (actionIndex)
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
                if (enemies.Length > 1) enemies[1].attack();
                else PlayActions();
                break;
            case 4:
                actionIndex = -1;
                actionMode = false;
                effectsMode = true;
                EffectsActions();
                break;
        }
    }

    public void EffectsActions()
    {
        actionIndex++;
        if (actionIndex >= allCharacters.Length)
        {
            effectsMode = false;
            DisposeDead();
        }
        else if (allCharacters[actionIndex].isPoisoned) allCharacters[actionIndex].poisonTick();
        else EffectsActions();
    }

    public void DisposeDead()
    {
        if (enemies[0].isDead)
        {
            if (enemies.Length > 1)
            {
                if (enemies[1].isDead)
                {
                    NextFight();
                    return;
                }
                else
                {
                    enemies = new EnemyScript[] { enemies[1] };
                }
            }
            else
            {
                if (enemies[1].isDead)
                {
                    enemies = new EnemyScript[] { enemies[0] };
                }
            }
        }
        Setup();
    }

    private void Win()
    {
        Debug.Log("WIN!");
    }

    public bool isAttacking()
    {
        return choseAttack;
    }

    public void animation_ended(CharacterScript character)
    {
        if (actionMode) PlayActions();
        else if (effectsMode) EffectsActions();
    }
}
