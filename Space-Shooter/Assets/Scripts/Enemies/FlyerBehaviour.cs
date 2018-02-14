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
        // Enable collider after spawn animation
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            collisionEnabled = true;
            spawnTime = 0;
        }
        if (collisionEnabled)
        {
            enemyCollider.enabled = true;
        }
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
