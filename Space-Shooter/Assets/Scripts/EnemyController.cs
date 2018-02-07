using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // Variables
    private Rigidbody enemyRigidbody;
    public float moveSpeed;

    private AccelerometerTest player;

    private void Start()
    {
       // enemyRigidbody = GetComponent<Rigidbody>();
        player = FindObjectOfType<AccelerometerTest>();
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Booooooom... Player destroyed");
            Destroy(gameObject);
        }
    }
}
