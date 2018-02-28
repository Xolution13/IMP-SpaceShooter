using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevel : MonoBehaviour
{
    // Variables
    private GameState stateScript;
    private GameScene sceneScript;
    private PlayerStatus status;
    private BorderSpawner borderSpawner;
    private EnemySpawner enemySpawner;
    private Intro endlessIntro;
    private float waitTime = 5;
    public float borderSpawnTime = 45;
    private bool spawnAttacker = true;
    private bool spawnFlyer = true;
    private bool spawnRockets = true;

    private void Start()
    {
        stateScript = GetComponent<GameState>();
        sceneScript = GetComponent<GameScene>();
        enemySpawner = GetComponent<EnemySpawner>();
        borderSpawner = GetComponent<BorderSpawner>();
        endlessIntro = GetComponent<Intro>();
        stateScript.gameTime = 0;
        stateScript.increaseTime = true;
    }

    // Check if the intro of endless modus was done
    private void Update()
    {
        if (endlessIntro.introIsDone)
        {
            waitTime -= Time.deltaTime;
            if(waitTime <= 0)
            {
                enemySpawner.spawnEnemies = true;
                waitTime = 5;
            }
        }

        if(stateScript.gameTime >= 60)
        {
            borderSpawnTime -= Time.deltaTime;
            if(borderSpawnTime <= 45 && spawnFlyer)
            {
                borderSpawner.spawnFlyer = true;
                spawnFlyer = false;
            }
            else if (borderSpawnTime <= 30 && spawnAttacker)
            {
                borderSpawner.spawnAttacker = true;
                spawnAttacker = false;
            }
            else if (borderSpawnTime <= 15 && spawnRockets)
            {
                borderSpawner.spawnRocket = true;
                spawnRockets = false;
            }
            else if(borderSpawnTime <= 0)
            {
                spawnFlyer = true;
                spawnAttacker = true;
                spawnRockets = true;
                borderSpawnTime = Random.Range(16, 46);
            }
        }
    }
}
