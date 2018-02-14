﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepsBehaviour : MonoBehaviour
{
    // Variables
    private Vector3 startPos;
    private Vector3 endPos;

    public float moveSpeed = 2.5f;
    private float distance;

    private bool onWayToStart = true;
    private bool onWayToEnd = false;

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

        // Border values: x-Min = -23, x-Max = 23, z-Min = -16, z-Max = 16
        startPos = new Vector3(Random.Range(-23, 23), transform.position.y, Random.Range(-16, 16));
        endPos = new Vector3(Random.Range(-23, 23), transform.position.y, Random.Range(-16, 16));
    }

    private void Update()
    {
        // Enable collider after spawn animation
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            collisionEnabled = true;
            spawnTime = 0;
        }
        
        if (collisionEnabled)
        {
            enemyCollider.enabled = true;

            // Check which way the enemy is going and change the direction after a specific distance has been reached
            if (onWayToStart && distance <= 1)
            {
                onWayToEnd = true;
                onWayToStart = false;
            }
            else if (onWayToEnd && distance <= 1)
            {
                onWayToStart = true;
                onWayToEnd = false;
            }

            // Movement: Rotate towards target, then move towards it
            if (onWayToStart)
            {
                onWayToEnd = false;
                distance = Vector3.Distance(transform.position, startPos);
                transform.LookAt(startPos);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else if (onWayToEnd)
            {
                onWayToStart = false;
                distance = Vector3.Distance(transform.position, endPos);
                transform.LookAt(endPos);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
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