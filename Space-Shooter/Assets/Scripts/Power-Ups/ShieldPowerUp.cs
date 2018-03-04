using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    // Variables
    public GameObject pickUpEffect;
    public GameObject shieldEffect;
    private GameState gameState;
    private GameObject shieldObject;
    private PlayerStatus player;
    private PowerUpSpawner spawnScript;
    private bool powerUpActivated = false;
    private float powerUpTime = 10;

    private void Awake()
    {
        gameState = FindObjectOfType<GameState>().GetComponent<GameState>();
        player = FindObjectOfType<PlayerStatus>();
        spawnScript = FindObjectOfType<PowerUpSpawner>().GetComponent<PowerUpSpawner>();
    }

    // Set shield position to player position and destroy it after time
    private void Update()
    {
		if (powerUpActivated)
        {
            shieldObject.transform.position = player.transform.position;

            powerUpTime -= Time.deltaTime;
			if (powerUpTime <= 0)
            {
                player.isInvulnerable = false;
                Destroy(shieldObject);
                spawnScript.stop = false;
				Destroy(gameObject);
			}
		}
	}

    // Check if the player is picking up
    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
        {
            powerUpActivated = true;
            PickUp();
		}
	}

    // Instantiate pick-up effect and enable power-up effect
    private void PickUp()
    {
        Instantiate(pickUpEffect, transform.position, transform.rotation);
        Debug.Log("Power-Up picked up!");
        gameState.powerUpsCollected++;
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        player.isInvulnerable = true;
        shieldObject = Instantiate(shieldEffect, player.transform.position, transform.rotation);
    }
}
