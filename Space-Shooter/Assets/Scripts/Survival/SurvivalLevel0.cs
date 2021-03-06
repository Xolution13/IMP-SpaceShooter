﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalLevel0 : MonoBehaviour
{
    // Variables
    private GameState stateScript;
    private GameScene sceneScript;
    private PlayerStatus status;

    public GameObject firstSpawn;
    private int firstSpawnEnemyAmount;
    private bool firstSpawnOnce = false;

    public GameObject secondSpawn;
    private float waitTime = 1f;
    private bool secondSpawnOnce = false;
    private int secondSpawnEnemyAmount;
    private bool gameOverOnce = true;

    private int totalEnemies;

    private void Start()
    {
        stateScript = GetComponent<GameState>();
        sceneScript = GetComponent<GameScene>();
        stateScript.gameTime = 30;
        stateScript.decreaseTime = true;

        firstSpawnEnemyAmount = firstSpawn.transform.childCount;
        secondSpawnEnemyAmount = secondSpawn.transform.childCount;
        totalEnemies = firstSpawnEnemyAmount + secondSpawnEnemyAmount;
    }

    private void Update()
    {
        // Spawn first wave after 1 seconds
        if (stateScript.gameTime <= 29 && !firstSpawnOnce)
        {
            Instantiate(firstSpawn, transform.position, Quaternion.identity);
            firstSpawnOnce = true;
        }

        // Spawn second wave after all enemies of the first wave are destroyed
        if (stateScript.destroyedEnemies == firstSpawnEnemyAmount && !secondSpawnOnce)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                Instantiate(secondSpawn, transform.position, Quaternion.identity);
                secondSpawnOnce = true;
            }
        }

        // Level is completed when all enemies are destroyed
        if (stateScript.destroyedEnemies == totalEnemies)
        {
            stateScript.greenColor = true;
            if (gameOverOnce)
            {
                stateScript.gameOver = true;
                gameOverOnce = false;
            }
            sceneScript.CompleteLevel();
        }

        // Level failed when time is up
        if (stateScript.gameTime <= 0)
        {
            stateScript.gameTime = 0;
            stateScript.redColor = true;
            if (gameOverOnce)
            {
                stateScript.gameOver = true;
                gameOverOnce = false;
            }
            sceneScript.LevelFailed();
        }
    }
}
