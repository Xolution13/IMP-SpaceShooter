using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerBehaviour : MonoBehaviour
{
    // Variables
    public float moveSpeed;

    private AccelerometerTest player;

    private bool collisionEnabled = false;
    private float spawnTime = 1.5f;
    private BoxCollider enemyCollider;
    
    private void Start()
    {
        player = FindObjectOfType<AccelerometerTest>();

        // Disable enemy collider so player can not get destroyed during spawn animation
        enemyCollider = GetComponent<BoxCollider>();
        enemyCollider.enabled = false;
    }

    private void FixedUpdate()
    {
        // Enable collider after spawn animation and move forwards
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            collisionEnabled = true;
            spawnTime = 0;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (collisionEnabled)
        {
            enemyCollider.enabled = true;
        }
    }

    // Look at the player (for transform.Translate -> forward)
    private void Update()
    {
        transform.LookAt(player.transform.position);
    }

    // Check if enemy is colliding with player
    private void OnCollisionEnter(Collision other)
    {
        if (collisionEnabled)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Booooooom... Player destroyed");
                Destroy(gameObject);
            }
        }
    }

}
