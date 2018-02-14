﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Variables
    public GameObject[] enemies;
    public GameObject spawnArea;

    private AccelerometerMovement player;
    private Vector3 center;
    private Vector3 size;
    private Vector3 pos;

    private int randomEnemyType;
    private int randomEnemyAmount;

    private void Start()
    {
        player = FindObjectOfType<AccelerometerMovement>();
    }

    private void Update()
    {
        // TODO: Spawn Logic (when do the enemies spawn?)
        if (Input.GetKeyDown(KeyCode.X))
        {
            SpawnEnemy();
        }
    }

    // Method to spawn random enemy amount of random enemy type
    private void SpawnEnemy()
    {
        randomEnemyAmount = Random.Range(0, 10);
        randomEnemyType = Random.Range(0, enemies.Length);

        center = spawnArea.transform.position;
        size = spawnArea.transform.localScale;
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z));

        // Make sure that the enemies are not spawning on top of player
        if (Vector3.Distance(player.transform.position, pos) >= 4)
        {
            for (int i = 0; i > randomEnemyAmount; i++)
            {
                randomEnemyType = randomEnemyType = Random.Range(0, enemies.Length);
                pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z));
                Instantiate(enemies[randomEnemyType], pos, Quaternion.identity);
            }
        }
    }
}
