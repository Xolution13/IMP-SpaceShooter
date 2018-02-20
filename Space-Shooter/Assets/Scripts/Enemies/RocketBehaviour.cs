using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    // Variables
    private PlayerStatus player;
    private EnemySpawnBehaviour spawnScript;

    public float moveSpeed = 10;
    private bool moveBack = false;
    private bool moveFront = true;
    private bool moveBackAfterRotation = false;
    private bool moveFrontAfterRotation = false;
    private bool startRotation = false;
    private float counter;
    private bool startCounter = false;
    private float currentRotationValue;
    private float startRotationValue;
    private float targetValue;
    private bool calculateTarget = true;

    private void Start()
    {
        player = FindObjectOfType<PlayerStatus>();
        spawnScript = GetComponent<EnemySpawnBehaviour>();
        Physics.IgnoreLayerCollision(10, 9, true);
    }

    private void Update()
    {
        if (spawnScript.spawnIsFinished)
        {
            // Limit position and rotation (so we do not have to use colliders)
            transform.position = new Vector3((Mathf.Clamp(transform.position.x, -34, 34)),
                                                transform.position.y,
                                                 Mathf.Clamp(transform.position.z, -19, 19));
            currentRotationValue = transform.eulerAngles.y;

            // Start smooth rotation with a counter as target value
            if (startCounter)
            {
                if (moveBack && !moveFront)
                {
                    moveFrontAfterRotation = true;
                    moveBack = false;
                    moveFront = false;
                }
                else if (moveFront && !moveBack)
                {
                    moveBackAfterRotation = true;
                    moveBack = false;
                    moveFront = false;
                }

                counter += 10;
                if (targetValue > 180)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, startRotationValue - counter, 0));
                }
                else if (targetValue <= 180)
                {
                    transform.rotation = Quaternion.Euler(new Vector3(0, startRotationValue + counter, 0));
                }
                if (counter == 190)
                {
                    counter = 0;
                    transform.rotation = Quaternion.Euler(new Vector3(0, targetValue, 0));
                    if (moveFrontAfterRotation)
                    {
                        moveFront = true;
                        moveBack = false;
                    }
                    else if (moveBackAfterRotation)
                    {
                        moveBack = true;
                        moveFront = false;
                    }
                    startCounter = false;
                    startRotation = false;
                    startRotationValue = currentRotationValue;
                    calculateTarget = true;
                }
            }

            if (startRotation)
            {
                CalculateRotationTarget();
            }

            if (moveFront)
            {
                moveBack = false;
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }

            if (moveBack)
            {
                moveFront = false;
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }
        }
    }

    // Calculate the target by checking if the value of y-axis is greater or less than 180
    private void CalculateRotationTarget()
    {
        if (currentRotationValue < 180)
        {
            if (calculateTarget)
            {
                startRotationValue = currentRotationValue;
                targetValue = startRotationValue + 180;
                startCounter = true;
                calculateTarget = false;
            }
        }
        else if (currentRotationValue >= 180)
        {
            if (calculateTarget)
            {
                startRotationValue = currentRotationValue;
                targetValue = currentRotationValue - 180;
                startCounter = true;
                calculateTarget = false;
            }
        }
    }
    
    // Check if we are colliding with the player or the boundary (boundary -> rotate 180)
    private void OnTriggerEnter(Collider other)
    {
        if (spawnScript.spawnIsFinished)
        {
            if (other.gameObject.tag == "Boundary")
            {
                startRotation = true;
            }
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
