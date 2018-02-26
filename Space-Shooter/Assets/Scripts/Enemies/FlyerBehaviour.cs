using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerBehaviour : MonoBehaviour
{
    // Variables
    public float moveSpeed;
    private PlayerStatus player;
    private EnemySpawnBehaviour spawnScript;
    private PlayerStatus status;
    private BoxCollider enemyCollider;
    
    private void Start()
    {
        player = FindObjectOfType<PlayerStatus>();
        spawnScript = GetComponent<EnemySpawnBehaviour>();
        status = player.GetComponent<PlayerStatus>();
    }

    private void FixedUpdate()
    {
        // Enemy moves forward when spawn process is finished
        if (spawnScript.spawnIsFinished && !status.isRespawning)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    // Look at the player (for transform.Translate -> forward)
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        transform.LookAt(player.transform.position);
    }

    // Check if enemy is colliding with player
    private void OnTriggerEnter(Collider other)
    {
        if (spawnScript.spawnIsFinished && !status.isRespawning)
        {
            if (other.gameObject.tag == "Player")
            {
                // Get the current health and substract it from itself to destroy
                player.GetComponent<PlayerStatus>().PlayerHit();
                int enemyHealth = GetComponent<EnemyHealthManager>().currentHealth;
                GetComponent<EnemyHealthManager>().HurtEnemy(enemyHealth);
            }
        }
    }
}
