using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // Variables
    public GameObject deathEffect;
    private GameState gameStateScript;
    private GameScene gameSceneScript;
    private Animator anim;
    public bool isInvulnerable = false;
    public int playerLifes = 3;
    public bool isRespawning = false;
    private float respawnTime = 2.5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        gameStateScript = FindObjectOfType<GameState>().GetComponent<GameState>();
        gameSceneScript = FindObjectOfType<GameScene>().GetComponent<GameScene>();
    }

    private void Update()
    {
        if (playerLifes <= 0)
        {
            // End game
            Debug.Log("Game-Over!");
            gameObject.SetActive(false);
            gameStateScript.gameOver = true;
            gameSceneScript.LevelFailed();
        }

        if (isRespawning)
        {
            respawnTime -= Time.deltaTime;
            if (respawnTime <= 0)
            {
                respawnTime = 2.5f;
                gameStateScript.countPlayTime = true;
                anim.SetBool("playSpawnAnimation", false);
                isRespawning = false;
            }
        }
    }

    public void PlayerHit()
    {
        if (!isInvulnerable)
        {
            playerLifes--;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Debug.Log(playerLifes);

            if (playerLifes > 0)
            {
                gameStateScript.countPlayTime = false;
                isRespawning = true;
                anim.SetBool("playSpawnAnimation", true);                
            }
        }
    }
}
