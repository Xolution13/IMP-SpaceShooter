using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour {

	private GameObject[] explosionObject;

	private float checkTime = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		checkTime -= Time.deltaTime;
		if (checkTime <= 0) {
		
			explosionObject = GameObject.FindGameObjectsWithTag ("Explosion");
			for (int i = 0; i < explosionObject.Length;i++){
			Destroy (explosionObject[i]);
			}
			checkTime = 5;

		}

	}
}
