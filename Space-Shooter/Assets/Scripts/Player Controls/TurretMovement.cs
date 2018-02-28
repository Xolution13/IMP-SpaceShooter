using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretMovement : MonoBehaviour {

    // Variables 
    private PlayerStatus status;
    private float hitDist = 0.0f;
    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;
    public GameObject improvedBulletPrefab;
    public float bulletFireRate = 0.1f;
    private float fireRate;
    private bool shootingActivated = false;
    public bool bulletPowerUpActive = false;

    private VirtualJoystick shootJoystick;
    private Image joystickImage;

    private void Start()
    {
        status = FindObjectOfType<PlayerStatus>().GetComponent<PlayerStatus>();
        fireRate = bulletFireRate;

        shootJoystick = GameObject.FindGameObjectWithTag("ShootingJoystick").GetComponent<VirtualJoystick>();
        joystickImage = GameObject.FindGameObjectWithTag("ShootingJoystick").GetComponent<Image>();
    }

    private void Update()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        if (SaveManager.Instance.GetControlStatus(true))
        {
            joystickImage.enabled = false;
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
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 15 * Time.deltaTime);
                    shootingActivated = true;
                }
            }
        }
        else
        {
            if (shootJoystick.InputDirection != Vector3.zero)
            {
                joystickImage.enabled = true;
                Quaternion targetRotation = Quaternion.LookRotation(shootJoystick.InputDirection, Vector3.zero);
                targetRotation.x = 0;
                targetRotation.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7 * Time.deltaTime);
                shootingActivated = true;
            }
        }

        // Activate shooting with set firerate
        if ((shootingActivated || Input.GetKey(KeyCode.M)) && !status.isRespawning)
        {
            fireRate -= Time.deltaTime;
            if (fireRate <= 0)
            {
                Shoot();
                shootingActivated = false;
                fireRate = bulletFireRate;
            }
        }

        // Increase firerate when power up is active
        if (bulletPowerUpActive)
        {
            bulletFireRate = 0.05f;
        }
        else
        {
            bulletFireRate = 0.15f;
        }
    }
    
    // CHeck if the player has power up active
    private void Shoot()
    {
        if (bulletPowerUpActive)
        {
            Instantiate(improvedBulletPrefab.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        }
        else if (!bulletPowerUpActive)
        {
            Instantiate(bulletPrefab.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}
