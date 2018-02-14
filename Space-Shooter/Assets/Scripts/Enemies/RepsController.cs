using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepsController : MonoBehaviour
{
    // Variables
    private Vector3 startPos;
    private Vector3 endPos;

    public float moveSpeed = 2.5f;
    private float distance;

    public bool onWayToStart = true;
    public bool onWayToEnd = false;

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

        startPos = new Vector3(transform.position.x + Random.Range(5, 10), transform.position.y, transform.position.z + Random.Range(5, 10));
        endPos = new Vector3(transform.position.x - Random.Range(5, 10), transform.position.y, transform.position.z - Random.Range(5, 10));
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Booooooom... Player destroyed");
            Destroy(gameObject);
        }
    }
}
