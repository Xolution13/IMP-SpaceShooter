using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
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

    void Update(){

		if (activated) {
			GetComponent<Renderer> ().enabled = false;
			//Player gets invulnerbility
			Debug.Log("Player invulnerable");

			powerUpTime -= Time.deltaTime;
			if (powerUpTime <= 1) {
				//Player normal again
				Debug.Log("Player not invulnerable anymore");
				spawner.stop = false;
				Destroy(this.gameObject);
			}
		}

	}


	void OnTriggerEnter(Collider objectToCollide){

		if (objectToCollide.gameObject == player) {

			activated = true;
		}

	}
}
