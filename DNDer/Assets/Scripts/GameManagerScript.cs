using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] LoverScript lover;
    [SerializeField] EnemyScript enemy;

    FightScript currentFight;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayer();
        SetEnemy();
    }

    private void SetEnemy()
    {
        player.enemy = enemy;
        lover.enemy = enemy;
        enemy.player = player;
    }

    private void SetPlayer()
    {
        lover.player = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
