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
    private Intro endlessIntro;
    private float waitTime = 5;

    private void Start()
    {
        stateScript = GetComponent<GameState>();
        sceneScript = GetComponent<GameScene>();
        enemySpawner = GetComponent<EnemySpawner>();
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
    }
}
