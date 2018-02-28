using System.Collections;
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
    public bool spawnEnemies = false;

    private int randomEnemyType;
    private int randomEnemyAmount;

    private void Start()
    {
        player = FindObjectOfType<AccelerometerMovement>();
    }

    private void Update()
    {
       
        if (spawnEnemies)
        {
            SpawnEnemy();
            spawnEnemies = false;
        }
    }

    // Method to spawn random enemy amount of random enemy type
    private void SpawnEnemy()
    {
        randomEnemyAmount = Random.Range(0, 10);
        randomEnemyType = Random.Range(0, enemies.Length);

        center = spawnArea.transform.position;
        size = spawnArea.transform.localScale;
        pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z / 2));

        // Make sure that the enemies are not spawning on top of player
        if (Vector3.Distance(player.transform.position, pos) >= 4)
        {
            for (int i = 0; i < randomEnemyAmount; i++)
            {
                randomEnemyType = Random.Range(0, enemies.Length);
                pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z / 2));
                Instantiate(enemies[randomEnemyType], pos, Quaternion.identity);
            }
        }
    }
}
