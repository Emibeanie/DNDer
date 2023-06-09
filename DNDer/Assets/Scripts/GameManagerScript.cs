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
    [SerializeField] public PlayerScript player;
    [SerializeField] FightScript[] fights;
    [SerializeField] Transform[] enemyPos;
    [SerializeField] Transform loverPos;
    [SerializeField] GameObject chooseUI;
    [SerializeField] GameObject strBarUI;
    [SerializeField] TextMeshProUGUI commentText;

    [SerializeField] float maxPerfectHit;
    [SerializeField] float maxSuccessfulHit;

    EnemyScript[] enemies;
    CharacterScript[] allCharacters;

    public LoverScript loverPrefab;
    public LoverScript lover;

    int currentFight = -1;
    bool choseAttack = true;
    float barScore = 0;

    bool actionMode = false;

    public DialogueScript dialogueBox;


    public List<turnAction> turnActions = new List<turnAction>();

    // Start is called before the first frame update
    void Start()
    {
        chooseUI.SetActive(false);
        strBarUI.SetActive(false);
        lover = Instantiate(loverPrefab);
        lover.transform.position = loverPos.position;
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
        if (barPos < maxPerfectHit)
        {
            barPos = 1;
            lover.CheckTriggers(AffectionTrigger.Trigger.perfect);
            if (choseAttack) lover.CheckTriggers(AffectionTrigger.Trigger.perfect_att);
            else lover.CheckTriggers(AffectionTrigger.Trigger.perfect_def);
        }
        else if (barPos > maxSuccessfulHit)
        {
            barPos = 0;
            lover.CheckTriggers(AffectionTrigger.Trigger.miss);
            if (choseAttack) lover.CheckTriggers(AffectionTrigger.Trigger.miss_hit);
            else lover.CheckTriggers(AffectionTrigger.Trigger.miss_def);
        }
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
