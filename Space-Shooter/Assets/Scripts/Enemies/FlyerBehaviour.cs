using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerBehaviour : MonoBehaviour
{
    // Variables
    public float moveSpeed;

    private PlayerStatus player;
    private EnemySpawnBehaviour spawnScript;

    private bool collisionEnabled = false;
    private float spawnTime = 1.5f;
    private BoxCollider enemyCollider;
    
    private void Start()
    {
        player = FindObjectOfType<PlayerStatus>();
        spawnScript = GetComponent<EnemySpawnBehaviour>();
    }

    private void FixedUpdate()
    {
        // Enemy moves forward when spawn process is finished
        if (spawnScript.spawnIsFinished)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    // Look at the player (for transform.Translate -> forward)
    private void Update()
    {
        transform.LookAt(player.transform.position);
    }

    // Check if enemy is colliding with player
    private void OnTriggerEnter(Collider other)
    {
        if (spawnScript.spawnIsFinished)
        {
            if (other.gameObject.tag == "Player")
            {
                player.GetComponent<PlayerStatus>().PlayerHit();
                Destroy(gameObject);
            }
        }
    }
}
