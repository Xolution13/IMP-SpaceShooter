using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // Variables
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    public int playerLifes = 3;

    private void Update()
    {
        if (playerLifes <= 0)
        {
            // End game
            Debug.Log("Game-Over!");
            gameObject.SetActive(false);
        }
    }

    public void PlayerHit()
    {
        if (!isInvulnerable)
        {
            playerLifes--;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Debug.Log(playerLifes);
        }
    }
}
