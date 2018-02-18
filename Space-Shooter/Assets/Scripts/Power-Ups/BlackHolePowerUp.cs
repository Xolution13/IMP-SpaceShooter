using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHolePowerUp : MonoBehaviour {

    // Variables
    public GameObject pickUpEffect;
    public GameObject blackHole;

    private PowerUpSpawner spawnScript;
    private bool powerUpActivated = false;
    private float powerUpTime = 10;

    private void Start()
    {
        spawnScript = FindObjectOfType<PowerUpSpawner>().GetComponent<PowerUpSpawner>();
    }

    // Spawn black hole if player is picking up
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Instantiate(pickUpEffect, transform.position, transform.rotation);
            Instantiate(blackHole, transform.position, Quaternion.Euler(new Vector3(270,0,0)));
            Destroy(gameObject);
        }
    }
}
