using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    // Variables
    public GameObject pickUpEffect;
    public GameObject shieldEffect;
    private GameObject shieldObject;
    private PlayerStatus player;
    private PlayerStatus playerScript;
    private PowerUpSpawner spawnScript;
    private bool powerUpActivated = false;
    private float powerUpTime = 10;

    private void Awake()
    {
        player = FindObjectOfType<PlayerStatus>();
        playerScript = player.GetComponent<PlayerStatus>();
        spawnScript = FindObjectOfType<PowerUpSpawner>().GetComponent<PowerUpSpawner>();
    }

    // Set shield position to player position and destroy it after time
    void Update()
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
        shieldObject = Instantiate(shieldEffect, player.transform.position, transform.rotation);
    }
}
