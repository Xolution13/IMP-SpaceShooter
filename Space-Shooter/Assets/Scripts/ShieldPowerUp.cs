using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour {

	// Variables
	private GameObject player;
	private PlayerTestMovement playerScript;
	private PowerUpSpawner spawner;
	private bool activated = false;

	private float powerUpTime = 10;

	void Awake(){

		player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = player.GetComponent<PlayerTestMovement>();
		spawner = GameObject.FindGameObjectWithTag("PowerUpSpawner").GetComponent<PowerUpSpawner>();

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
