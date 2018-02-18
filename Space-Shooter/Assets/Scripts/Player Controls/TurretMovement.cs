using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour {

    // Variables 
    private float hitDist = 0.0f;
    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;
    public GameObject improvedBulletPrefab;
    public float bulletFireRate = 0.1f;
    private float fireRate;
    private bool shootingActivated = false;
    public bool bulletPowerUpActive = false;

    private void Start()
    {
        fireRate = bulletFireRate;
    }

    private void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Rotate the player to the position
        if (Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (playerPlane.Raycast(ray, out hitDist))
            {
                Vector3 targetPoint = ray.GetPoint(hitDist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                targetRotation.x = 0;
                targetRotation.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
                shootingActivated = true;
            }
        }

        // Activate shooting with set firerate
        if (shootingActivated)
        {
            fireRate -= Time.deltaTime;
            if (fireRate <= 0)
            {
                Shoot();
                shootingActivated = false;
                fireRate = bulletFireRate;
            }
        }
    }
    
    // CHeck if the player has power up active
    private void Shoot()
    {
        if (bulletPowerUpActive)
        {
            Instantiate(bulletPrefab.transform, bulletSpawnPoint.transform.position, Quaternion.Euler(0, transform.eulerAngles.y, 0));
        }
        else if (!bulletPowerUpActive)
        {
            Instantiate(improvedBulletPrefab.transform, bulletSpawnPoint.transform.position, Quaternion.Euler(0, transform.eulerAngles.y, 0));
        }
    }
}
