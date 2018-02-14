using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Variables
    public float speed;
    public float travelTime;
    private float maxTravelDistance;
    private TurretMovement playerDirection;
    private Vector3 touchPosition;
    public int damageValue;

    private void Start()
    {
        playerDirection = FindObjectOfType<TurretMovement>();
        touchPosition = playerDirection.transform.forward;
    }

    private void Update()
    {
        transform.Translate(touchPosition * Time.deltaTime * speed);
        maxTravelDistance += Time.deltaTime;

        if (maxTravelDistance >= travelTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageValue);
            Destroy(gameObject);
            Debug.Log("Enemy destroyed");
        }

    }
}
