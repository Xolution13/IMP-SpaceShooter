using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePowerUp : MonoBehaviour
{
    // Variables
    public GameObject pickUpEffect;
    private PlayerStatus player;
    private PlayerStatus playerScript;
    private PowerUpSpawner spawnScript;

    private void Awake()
    {
        player = FindObjectOfType<PlayerStatus>();
        playerScript = player.GetComponent<PlayerStatus>();
        spawnScript = FindObjectOfType<PowerUpSpawner>().GetComponent<PowerUpSpawner>();
    }

    // Add extra life if player is picking up
    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
        {
            //Instantiate(pickUpEffect, transform.position, transform.rotation);
            playerScript.playerLifes++;
			spawnScript.stop = false;
			Destroy(gameObject);
		}
	}
}
