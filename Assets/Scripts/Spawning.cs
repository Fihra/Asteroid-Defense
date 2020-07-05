﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public List <GameObject> enemies;
    public Transform spawnLocation;

    public int enemyCount = 3;
    public int bigEnemyCount = 3;
    public int hordeMultiplier = 1;

    public enum EnemyLevel { LEVEL1 = 0, LEVEL2 = 20, LEVEL3 = 50, LEVEL4 = 100, LEVEL5 = 200 };

    //float x;
    //float y = 10.0f;

    /*Level 1
     * Starting off falling meteors
     *
     * 
     * 
     */


    public static EnemyLevel currentLevel = EnemyLevel.LEVEL1;

    public static List<GameObject> enemiesInArea = new List<GameObject>();

    void Update()
    {
        Debug.Log("Enemies in Area: " + enemiesInArea.Count);
        if (enemiesInArea.Count <= 0)
        {
            SpawnHorde();
        } 
    }

    public void EnemiesLevel1And2()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject newEnem = Instantiate(enemies[0], spawnLocation.position, Quaternion.identity);
            enemiesInArea.Add(newEnem);
        }
    }

    public void EnemiesLevel3()
    {
        GameObject newBigEnem = Instantiate(enemies[1], spawnLocation.position, Quaternion.identity);
        enemiesInArea.Add(newBigEnem);
    }

    public void EnemiesLevel4()
    {
        for (int i = 0; i < bigEnemyCount; i++)
        {
            GameObject newBigEnem = Instantiate(enemies[1], spawnLocation.position, Quaternion.identity);
            enemiesInArea.Add(newBigEnem);
        }
    }

    public void SpawnHorde()
    {
        Debug.Log(currentLevel);
        switch (currentLevel)
        {
            case EnemyLevel.LEVEL1:
                if(SpacePlayer.score >= (int)EnemyLevel.LEVEL2)
                {
                    currentLevel = EnemyLevel.LEVEL2;
                    return;
                } 
                EnemiesLevel1And2();
                return;
            case EnemyLevel.LEVEL2:
                if(SpacePlayer.score >= (int)EnemyLevel.LEVEL3)
                {
                    currentLevel = EnemyLevel.LEVEL3;
                    return;
                }
                enemyCount++;
                hordeMultiplier++;
                EnemiesLevel1And2();
                return;
            case EnemyLevel.LEVEL3:
                if (SpacePlayer.score >= (int)EnemyLevel.LEVEL4)
                {
                    currentLevel = EnemyLevel.LEVEL4;
                    return;
                }
                enemyCount++;
                hordeMultiplier++;
                EnemiesLevel1And2();
                EnemiesLevel3();
                return;
            case EnemyLevel.LEVEL4:
                if (SpacePlayer.score >= (int)EnemyLevel.LEVEL5)
                {
                    currentLevel = EnemyLevel.LEVEL5;
                    return;
                }
                enemyCount++;
                bigEnemyCount++;
                hordeMultiplier++;
                EnemiesLevel1And2();
                EnemiesLevel4();
                return;
            default:
                return;

        }

        //Level 2
        //if(SpacePlayer.score >= 10 && SpacePlayer.score <= 50)
        //{
        //    currentLevel = EnemyLevel.LEVEL2;
        //    enemyCount++;
        //    hordeMultiplier++;
        //}
        ////enemyCount = enemyCount * hordeMultiplier;
        //EnemiesLevel1And2();

        //if(SpacePlayer.score >= 51 && SpacePlayer.score < 100)
        //{
        //    currentLevel = EnemyLevel.LEVEL3;
        //    enemyCount++;
        //    hordeMultiplier++;
        //}

        //if(currentLevel == EnemyLevel.LEVEL3)
        //{
        //    EnemiesLevel3();
        //}
    }
}
