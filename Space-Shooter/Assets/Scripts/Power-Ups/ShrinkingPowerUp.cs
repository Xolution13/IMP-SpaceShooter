using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPowerUp : MonoBehaviour {

    // Variables
    public GameObject pickUpEffect;
    private PlayerStatus player;
    private PlayerStatus playerScript;
    private PowerUpSpawner spawnScript;
    private bool powerUpActivated = false;
    private Vector3 originalScale;
    private float powerUpTime = 10;

    private void Start()
    {
        player = FindObjectOfType<PlayerStatus>();
        playerScript = player.GetComponent<PlayerStatus>();
        spawnScript = FindObjectOfType<PowerUpSpawner>().GetComponent<PowerUpSpawner>();
        originalScale = transform.localScale;
    }

    // After end of time set player-size back to original size
    private void Update()
    {
        if (powerUpActivated)
        {
            powerUpTime -= Time.deltaTime;
            if (powerUpTime <= 0)
            {
                Instantiate(pickUpEffect, transform.position, transform.rotation);
                player.transform.localScale = originalScale;
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
        player.transform.localScale *= 0.5f;
        Debug.Log("Power-Up picked up!");
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
