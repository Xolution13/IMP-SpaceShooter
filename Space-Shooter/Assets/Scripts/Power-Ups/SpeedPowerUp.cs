using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    // Variables
	public GameObject pickUpEffect;
	private AccelerometerMovement player;
	private AccelerometerMovement playerScript;
	private PowerUpSpawner spawnScript;
	private bool powerUpActivated = false;
	private float powerUpTime = 10;

	private void Start()
    {
		player = FindObjectOfType<AccelerometerMovement>();
		playerScript = player.GetComponent<AccelerometerMovement>();
        spawnScript = FindObjectOfType<PowerUpSpawner>().GetComponent<PowerUpSpawner>();
	}

    // Reset power-up effect after time, destroy power-up and allow next spawn
    private void Update()
    {
		if (powerUpActivated)
        {
			powerUpTime -= Time.deltaTime;
			if (powerUpTime <= 0)
            {
				Debug.Log ("Speed reset");
				playerScript.movementSpeed = 50;
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
        //Instantiate(pickUpEffect, transform.position, transform.rotation);
        Debug.Log("Power-Up picked up!");
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        playerScript.movementSpeed = 80;
    }
}
