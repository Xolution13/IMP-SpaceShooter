using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Variables
    public GameObject repSpawnOne;
    public GameObject repSpawnTwo;
    public GameObject repSpawnThree;
    public GameObject flyerSpawnOne;
    public GameObject flyerSpawnTwo;
    public GameObject flyerSpawnThree;
    public GameObject dancerSpawnOne;
    public GameObject dancerSpawnTwo;
    public GameObject dancerSpawnThree;
    public GameObject attackerSpawnOne;
    public GameObject attackerSpawnTwo;
    public GameObject rocketSpawnOne;
    public GameObject rocketSpawnTwo;
    public GameObject finalEntrySpawn;

    private GameState stateScript;
    private GameScene sceneScript;
    private EnemySpawner enemySpawner;
    public bool introIsDone = false;

    private bool firstSpawn = true;
    private bool secondSpawn = true;
    private bool thirdSpawn = true;
    private bool fourthSpawn = true;
    private bool fivthSpawn = true;
    private bool sixthSpawn = true;
    private bool seventhSpawn = true;
    private bool eigthSpawn = true;
    private bool ninethSpawn = true;
    private bool tenthSpawn = true;
    private bool eleventhSpawn = true;
    private bool twelvethSpawn = true;
    private bool thriteenthSpawn = true;
    private bool fourteenthSpawn = true;


    private void Start()
    {
        stateScript = GetComponent<GameState>();
        sceneScript = GetComponent<GameScene>();
        enemySpawner = GetComponent<EnemySpawner>();
    }

    private void Update()
    {
        // First spawn reps
        if (stateScript.gameTime >= 1 && firstSpawn)
        {
            Instantiate(repSpawnOne, transform.position, Quaternion.identity);
            firstSpawn = false;
        }
        if (stateScript.gameTime >= 4 && secondSpawn)
        {
            Instantiate(repSpawnTwo, transform.position, Quaternion.identity);
            secondSpawn = false;
        }
        if (stateScript.gameTime >= 8 && thirdSpawn)
        {
            Instantiate(repSpawnThree, transform.position, Quaternion.identity);
            thirdSpawn = false;
        }

        // Spawn flyer
        if (stateScript.gameTime >= 13 && fourthSpawn)
        {
            Instantiate(flyerSpawnOne, transform.position, Quaternion.identity);
            fourthSpawn = false;
        }
        if (stateScript.gameTime >= 18 && fivthSpawn)
        {
            Instantiate(flyerSpawnTwo, transform.position, Quaternion.identity);
            fivthSpawn = false;
        }
        if (stateScript.gameTime >= 21 && sixthSpawn)
        {
            Instantiate(flyerSpawnThree, transform.position, Quaternion.identity);
            sixthSpawn = false;
        }

        // Spawn dancer
        if (stateScript.gameTime >= 24 && seventhSpawn)
        {
            Instantiate(dancerSpawnOne, transform.position, Quaternion.identity);
            seventhSpawn = false;
        }
        if (stateScript.gameTime >= 28 && eigthSpawn)
        {
            Instantiate(dancerSpawnTwo, transform.position, Quaternion.identity);
            eigthSpawn = false;
        }
        if (stateScript.gameTime >= 32 && ninethSpawn)
        {
            Instantiate(dancerSpawnThree, transform.position, Quaternion.identity);
            ninethSpawn = false;
        }

        // Spawn attacker
        if (stateScript.gameTime >= 35 && tenthSpawn)
        {
            Instantiate(attackerSpawnOne, transform.position, Quaternion.identity);
            tenthSpawn = false;
        }
        if (stateScript.gameTime >= 39 && eleventhSpawn)
        {
            Instantiate(attackerSpawnTwo, transform.position, Quaternion.identity);
            introIsDone = true;
            eleventhSpawn = false;
        }

        // Spawn rocktets
        if (stateScript.gameTime >= 44 && twelvethSpawn)
        {
            Instantiate(rocketSpawnOne, transform.position, Quaternion.identity);
            twelvethSpawn = false;
        }
        if (stateScript.gameTime >= 49 && thriteenthSpawn)
        {
            Instantiate(rocketSpawnTwo, transform.position, Quaternion.identity);
            thriteenthSpawn = false;
        }

        // Spawn last intro
        if (stateScript.gameTime >= 52 && fourteenthSpawn)
        {
            Instantiate(finalEntrySpawn, transform.position, Quaternion.identity);
            fourteenthSpawn = false;
        }

    }
}
