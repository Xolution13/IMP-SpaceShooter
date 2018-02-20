using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    // Variables
    public GameObject deathEffect;
    public int health;
    public int currentHealth;

    private void Start()
    {
        currentHealth = health;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
