using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalLevel0 : MonoBehaviour
{
    private GameState stateScript;
    private GameScene sceneScript;
    private PlayerStatus status;

    public GameObject firstSpawn;
    private bool firstSpawnOnce = false;
    public GameObject secondSpawn;

    private GameObject[] enemiesAlive;

    private void Start()
    {
        stateScript = GetComponent<GameState>();
        sceneScript = GetComponent<GameScene>();
        stateScript.gameTime = 30;
    }

    private void Update()
    {
        if (stateScript.gameTime <= 28 && !firstSpawnOnce)
        {
            Instantiate(firstSpawn, transform.position, Quaternion.identity);
            firstSpawnOnce = true;
        }

        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemiesAlive.Length; i++)
        {
            if (!enemiesAlive[i])
            {
                Instantiate(secondSpawn, transform.position, Quaternion.identity);
            }
        }
        

        // Level failed when time is up
        if (stateScript.gameTime <= 0)
        {
            sceneScript.LevelFailed();
        }
    }
}
