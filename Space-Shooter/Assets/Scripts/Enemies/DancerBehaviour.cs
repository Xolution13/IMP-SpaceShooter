using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancerBehaviour : MonoBehaviour
{
    // Variables
    private GameObject[] bullet;
    private AccelerometerMovement player;
    private Vector3 velocity = Vector3.zero;
    public float distanceToBullet;
    public float moveSpeed = 3;
    public float dodgeSpeed = 4;
    public int randomNumber;
    public string direction;
    public bool isChasingPlayer = true;
    public bool isDodgingBullet = false;

    private void Start()
    {
        bullet = GameObject.FindGameObjectsWithTag("Bullet");
        player = FindObjectOfType<AccelerometerMovement>();
        randomNumber = Random.Range(0, 2);
    }

    private void Update()
    {
        bullet = GameObject.FindGameObjectsWithTag("Bullet");
        transform.position = new Vector3((Mathf.Clamp(transform.position.x, -24, 24)),
                                            transform.position.y,
                                            Mathf.Clamp(transform.position.z, -16.5f, 16.5f));

        if (isChasingPlayer && !isDodgingBullet)
        {
            transform.LookAt(player.transform.position);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        for (int i = 0; i < bullet.Length; i++)
        {
            distanceToBullet = Vector3.Distance(transform.position, bullet[i].transform.position);

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
            else
            {
                isDodgingBullet = false;
            }
        }
    }
}
