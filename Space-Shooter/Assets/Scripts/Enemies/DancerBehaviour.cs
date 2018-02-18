using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerBehaviour : MonoBehaviour
{
    // Variables
    private GameObject[] bullet;
    private AccelerometerMovement player;
    private Vector3 velocity = Vector3.zero;
    private float distanceToBullet;
    public float moveSpeed = 3;
    public float dodgeSpeed = 4;
    private int randomNumber;
    private bool inBulletLine = false;
    private bool isChasingPlayer = true;
    private bool isDodgingBullet = false;

    private void Start()
    {
        bullet = GameObject.FindGameObjectsWithTag("Bullet");
        player = FindObjectOfType<AccelerometerMovement>();
        randomNumber = Random.Range(0, 2);
    }

    private void Update()
    {
        // Update bullets as they spawn
        bullet = GameObject.FindGameObjectsWithTag("Bullet");

        // Limit position and rotation (so we do not have to use colliders)
        transform.position = new Vector3((Mathf.Clamp(transform.position.x, -24, 24)),
                                            transform.position.y,
                                            Mathf.Clamp(transform.position.z, -16.5f, 16.5f));
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0));

        // If the enemy is not in front of player and the player is not shooting
        if (isChasingPlayer && !isDodgingBullet && !inBulletLine)
        {
            transform.LookAt(player.transform.position);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // Calculate distance to every bullet and dodge it if enemy is in front of player
        for (int i = 0; i < bullet.Length; i++)
        {
            distanceToBullet = Vector3.Distance(transform.position, bullet[i].transform.position);

            if (inBulletLine)
            {
                if (distanceToBullet <= 10)
                {
                    isDodgingBullet = true;
                    transform.LookAt(Vector3.SmoothDamp(transform.position, bullet[i].transform.position, ref velocity, 0.5f));

                    if (randomNumber == 0)
                    {
                        transform.Translate((Vector3.back + Vector3.right) * dodgeSpeed * Time.deltaTime);
                    }
                    else if (randomNumber == 1)
                    {
                        transform.Translate((Vector3.back + Vector3.left) * dodgeSpeed * Time.deltaTime);
                    }
                }
            }
            else
            {
                isDodgingBullet = false;
            }
        }
    }

    // Check if enemy is in front of player or not
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "POV")
        {
            inBulletLine = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "POV")
        {
            inBulletLine = false;
        }
    }
}
