using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour {

	// Variables
	private GameObject player;
	private PlayerTestMovement playerScript;
	private PowerUpSpawner spawner;

	void Awake(){

		player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = player.GetComponent<PlayerTestMovement>();
		spawner = GameObject.FindGameObjectWithTag("PowerUpSpawner").GetComponent<PowerUpSpawner>();

	}

	void OnTriggerEnter(Collider objectToCollide){

		if (objectToCollide.gameObject == player) {
			
			// Player HP ++
			Debug.Log("Player HP++");
			spawner.stop = false;
			Destroy(this.gameObject);

		}

	}
}
