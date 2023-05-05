using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;
using Mono.Collections.Generic;

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


    public List<turnAction> turnActions = new List<turnAction>();

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
        CollectActions();
    }

    public void CollectActions()
    {
        if (choseAttack)
            turnActions.Add(new turnAction(turnAction.ActionType.playerAttack, player, "player_attack", 0, barScore));
        else
            turnActions.Add(new turnAction(turnAction.ActionType.playerDeffend, player, "player_attack", 0, barScore));

        for(int i = 1; i < allCharacters.Length;i++)
        {
            turnActions.Add(new turnAction(turnAction.ActionType.attack, allCharacters[i], "player_attack"));
        }

        for(int i = 0; i < allCharacters.Length; i++)
        {
            if (allCharacters[i].isPoisoned)
                turnActions.Add(new turnAction(turnAction.ActionType.takePoisonDamage, allCharacters[i], "player_attack"));
        }

        actionMode = true;
        PlayActions();
    }

    public void EffectsActions()
    {
        actionIndex++;
        if (actionIndex >= allCharacters.Length)
        {
            actionIndex = -1;
            DisposeDead();
        }
        else if (allCharacters[actionIndex].isPoisoned) allCharacters[actionIndex].poisonTick();
        else EffectsActions();
    }

    public void PlayActions()
    {
        if (turnActions.Count > 0)
        {
            turnAction action = turnActions[0];
            turnActions.RemoveAt(0);
            action.CallAction();
            
        }
        else
        {
            actionMode = false;
            DisposeDead();
        }
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
    }
}
