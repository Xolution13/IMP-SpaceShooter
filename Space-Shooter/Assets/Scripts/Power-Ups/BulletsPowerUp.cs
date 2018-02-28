using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPowerUp : MonoBehaviour
{
    // Variables
    public GameObject pickUpEffect;
    private GameState gameState;
    private PlayerStatus player;
    private TurretMovement playerScript;
    private PowerUpSpawner spawnScript;
    private bool powerUpActivated = false;
    private float powerUpTime = 10;

    private void Start()
    {
        gameState = FindObjectOfType<GameState>().GetComponent<GameState>();
        player = FindObjectOfType<PlayerStatus>();
        playerScript = FindObjectOfType<TurretMovement>().GetComponent<TurretMovement>();
        spawnScript = FindObjectOfType<PowerUpSpawner>().GetComponent<PowerUpSpawner>();
    }

    // Disable power-up after time
    private void Update()
    {
        if (powerUpActivated)
        {
            powerUpTime -= Time.deltaTime;
            if (powerUpTime <= 0)
            {
                playerScript.bulletPowerUpActive = false;
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
        playerScript.bulletPowerUpActive = true;
    }
}
