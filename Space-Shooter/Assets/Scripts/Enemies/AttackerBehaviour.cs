using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerBehaviour : MonoBehaviour
{
    // Variables
    public GameObject[] destroyedParts;
    private AccelerometerMovement player;
    private Bullet[] bullet;
    private EnemyHealthManager healthScript;
    private EnemySpawnBehaviour spawnScript;
    public float moveSpeed = 8;
    private bool onlyDoOnce = true;

    private void Start()
    {
        player = FindObjectOfType<AccelerometerMovement>();
        healthScript = GetComponent<EnemyHealthManager>();
        spawnScript = GetComponent<EnemySpawnBehaviour>();
    }

    private void Update()
    {
        if (spawnScript.spawnIsFinished)
        {
            // Enemy moves towards the player
            transform.LookAt(player.transform.position);
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0));
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Check the health and dismantle (spawn prefabs) if health = 0
            if (healthScript.currentHealth <= 0 && onlyDoOnce)
            {
                for (int i = 0; i < destroyedParts.Length; i++)
                {
                    DismantleInParts(i);
                }
                onlyDoOnce = false;
            }
        }
    }

    // Instantiate Prefab
    private void DismantleInParts(int numberOfPart)
    {
        Instantiate(destroyedParts[numberOfPart], transform.position, gameObject.transform.rotation);
    }

    // Check if enemy is colliding with player
    private void OnTriggerEnter(Collider other)
    {
        if (spawnScript.spawnIsFinished)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Booooooom... Player destroyed");
                Destroy(gameObject);
            }
        }
    }
}
