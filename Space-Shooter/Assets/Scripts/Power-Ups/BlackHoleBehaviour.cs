using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBehaviour : MonoBehaviour
{
    // Variables
    private GameObject[] enemy;
    private PowerUpSpawner spawnScript;
    private Vector3 velocity = Vector3.zero;
    private float powerUpTime = 10;

    private void Start()
    {
        spawnScript = FindObjectOfType<PowerUpSpawner>().GetComponent<PowerUpSpawner>();
    }

    private void Update()
    {
        powerUpTime -= Time.deltaTime;
        if (powerUpTime <= 0)
        {
            spawnScript.stop = false;
            Destroy(gameObject);
        }

        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy.Length; i++)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy[i].transform.position);

            if (distanceToEnemy <= 5)
            {
                enemy[i].transform.position = Vector3.SmoothDamp(enemy[i].transform.position, transform.position, ref velocity, 0.2f);
                   // Vector3.MoveTowards(enemy[i].transform.position, transform.position, 0.3f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
