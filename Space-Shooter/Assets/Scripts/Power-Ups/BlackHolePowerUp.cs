using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHolePowerUp : MonoBehaviour {

    // Variables
    public GameObject pickUpEffect;
    public GameObject blackHole;

    // Spawn black hole if player is picking up
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(pickUpEffect, transform.position, transform.rotation);
            Instantiate(blackHole, transform.position, Quaternion.Euler(new Vector3(270,0,0)));
            Destroy(gameObject);
        }
    }
}
