using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour {

    // Variables
	public GameObject explosionAnimation;
	private GameObject player;
	private AccelerometerTest playerScript;
	private PowerUpSpawner spawner;
	private bool activated = false;
	private bool doOnce = true;

	private float powerUpTime = 10;

	private void Awake(){
	
		player = GameObject.FindGameObjectWithTag ("Player");
		playerScript = player.GetComponent<AccelerometerTest>();
		spawner = GameObject.FindGameObjectWithTag("PowerUpSpawner").GetComponent<PowerUpSpawner>();

	}

	private void Update(){
	
		if (activated) {
			GetComponent<Renderer> ().enabled = false;
			playerScript.movementSpeed = 80;
			if (doOnce) {
				Instantiate (explosionAnimation, this.transform.position, this.transform.rotation);
				doOnce = false;
			}

			powerUpTime -= Time.deltaTime;
			if (powerUpTime <= 1) {
				Debug.Log ("Speed reset");
				playerScript.movementSpeed = 50;
				spawner.stop = false;
				Destroy(this.gameObject);
			}
		}

	}


	private void OnTriggerEnter(Collider objectToCollide){

		if (objectToCollide.gameObject == player) {

			activated = true;
		}

	}
		
}
