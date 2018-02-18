using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerBehaviour : MonoBehaviour
{
    // Variables
    private Bullet[] bullet;
    private PlayerStatus player;
    private EnemySpawnBehaviour spawnScript;
    private Vector3 velocity = Vector3.zero;
    private float distanceToBullet;
    public float moveSpeed = 3;
    public float dodgeSpeed = 4;
    private int randomNumber;
    private bool inBulletLine = false;
    private bool isDodgingBullet = false;

    private void Start()
    {
        bullet = FindObjectsOfType<Bullet>();
        player = FindObjectOfType<PlayerStatus>();
        spawnScript = GetComponent<EnemySpawnBehaviour>();
        randomNumber = Random.Range(0, 2);
    }

    private void Update()
    {
        // Update bullets as they spawn
        bullet = FindObjectsOfType<Bullet>();

        if (spawnScript.spawnIsFinished)
        {
            // Limit position and rotation (so we do not have to use colliders)
            transform.position = new Vector3((Mathf.Clamp(transform.position.x, -24, 24)),
                                                transform.position.y,
                                                Mathf.Clamp(transform.position.z, -16.5f, 16.5f));
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, 0));

            // If the enemy is not in front of player and the player is not shooting
            if (!isDodgingBullet)
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
    }

    // Check if enemy is in front of player or not
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "POV")
        {
            inBulletLine = true;
        }

        if (spawnScript.spawnIsFinished)
        {
            if (other.gameObject.tag == "Player")
            {
                player.GetComponent<PlayerStatus>().PlayerHit();
                Destroy(gameObject);
            }
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
