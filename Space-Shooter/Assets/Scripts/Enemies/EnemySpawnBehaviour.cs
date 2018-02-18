using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBehaviour : MonoBehaviour
{
    // Variables
    public bool spawnIsFinished = false;
    private float spawnTime = 1.5f;
    private BoxCollider enemyCollider;

    private void Start()
    {
        // Disable enemy collider so player can not get destroyed during spawn animation
        enemyCollider = GetComponent<BoxCollider>();
        enemyCollider.enabled = false;
    }

    private void Update () {
        // Enable collider after spawn animation and move forwards
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnIsFinished = true;
            enemyCollider.enabled = true;
            spawnTime = 0;
        }
    }
}
