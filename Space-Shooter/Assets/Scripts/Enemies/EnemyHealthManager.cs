using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    // Variables
    public GameObject deathEffect;
    private GameState gameState;
    public int health;
    public int points;
    public int currentHealth;
    private bool doOnce = true;

    private void Start()
    {
        gameState = FindObjectOfType<GameState>().GetComponent<GameState>();
        currentHealth = health;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            if (doOnce)
            {
                gameState.destroyedEnemies++;
                gameState.levelScore += points;
                doOnce = false;
            }
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
