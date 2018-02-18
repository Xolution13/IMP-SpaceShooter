using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSmallBehaviour : MonoBehaviour
{
    // Variables
    private PlayerStatus player;
    private EnemySpawnBehaviour spawnScript;
    private Vector3 spawnVector;
    private Vector3 movingVector;

    public float moveSpeed = 2;
    private float timeCounter = 0;
    private float circleWidth;
    private float circleHeigth;
    private int circleDirection;

    private void Start()
    {
        player = FindObjectOfType<PlayerStatus>();
        spawnScript = GetComponent<EnemySpawnBehaviour>();
        spawnVector = transform.position;
        circleWidth = Random.Range(2, 5);
        circleHeigth = Random.Range(2, 7);
        circleDirection = Random.Range(0, 2);
    }

    private void Update()
    {
        // Limit the position to play field and only allow y-Rotation
        transform.position = new Vector3((Mathf.Clamp(transform.position.x, -24, 24)),
                                                transform.position.y,
                                                Mathf.Clamp(transform.position.z, -16.5f, 16.5f));
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0));

        if (circleDirection == 1)
        {
            timeCounter += Time.deltaTime * moveSpeed;
        }
        else
        {
            timeCounter -= Time.deltaTime * moveSpeed;
        }
        float x = Mathf.Cos(timeCounter) * circleWidth;
        float z = Mathf.Sin(timeCounter) * circleHeigth;
        movingVector = new Vector3(x, 0.5f, z);
        transform.position = spawnVector + movingVector;
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
