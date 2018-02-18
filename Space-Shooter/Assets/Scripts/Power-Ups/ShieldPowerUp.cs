using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    // Variables
    public GameObject pickUpEffect;
    private PlayerStatus player;
    private PlayerStatus playerScript;
    private PowerUpSpawner spawnScript;
    private bool powerUpActivated = false;
    private float powerUpTime = 10;

    private void Start()
    {
        player = FindObjectOfType<PlayerStatus>();
        playerScript = player.GetComponent<PlayerStatus>();
        spawnScript = FindObjectOfType<PowerUpSpawner>().GetComponent<PowerUpSpawner>();
    }

    // Reset power-up effect after time, destroy power-up and allow next spawn
    void Update()
    {
		if (powerUpActivated)
        {
			powerUpTime -= Time.deltaTime;
			if (powerUpTime <= 1)
            {
                player.isInvulnerable = false;
                Debug.Log("Player not invulnerable anymore");
                spawnScript.stop = false;
				Destroy(gameObject);
			}
		}
	}

    // Check if the player is picking up
    void OnTriggerEnter(Collider other)
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
        //Instantiate(pickUpEffect, transform.position, transform.rotation);
        Debug.Log("Power-Up picked up!");
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        player.isInvulnerable = true;
    }
}
