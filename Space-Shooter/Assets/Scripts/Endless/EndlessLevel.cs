using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevel : MonoBehaviour
{
    // Variables
    private GameState stateScript;
    private GameScene sceneScript;
    private PlayerStatus status;
    private EnemySpawner enemySpawner;

    private bool firstSpawn = true;
    private bool secondSpawn = true;
    private bool thirdSpawn = true;
    private bool fourthSpawn = true;

    private void Start()
    {
        stateScript = GetComponent<GameState>();
        sceneScript = GetComponent<GameScene>();
        enemySpawner = GetComponent<EnemySpawner>();
        stateScript.gameTime = 0;
        stateScript.increaseTime = true;
    }

    private void Update()
    {
        if (stateScript.gameTime >= 2 && firstSpawn)
        {
            enemySpawner.spawnEnemies = true;
            firstSpawn = false;
        }

        if (stateScript.gameTime >= 8 && secondSpawn)
        {
            enemySpawner.spawnEnemies = true;
            secondSpawn = false;
        }

        if (stateScript.gameTime >= 12 && thirdSpawn)
        {
            enemySpawner.spawnEnemies = true;
            thirdSpawn = false;
        }

        if (stateScript.gameTime >= 17 && fourthSpawn)
        {
            enemySpawner.spawnEnemies = true;
            fourthSpawn = false;
        }
    }
}
