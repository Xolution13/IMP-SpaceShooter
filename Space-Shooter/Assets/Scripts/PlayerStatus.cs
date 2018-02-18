using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // Variables
    public bool isInvulnerable = false;
    public int playerLifes = 3;

    private void Update()
    {
        if (playerLifes <= 0)
        {
            Debug.Log("Game-Over!");
        }
    }

    public void PlayerHit()
    {
        if (!isInvulnerable)
        {
            playerLifes--;
            Debug.Log(playerLifes);
        }
    }
}
