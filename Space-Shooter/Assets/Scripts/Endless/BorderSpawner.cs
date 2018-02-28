using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderSpawner : MonoBehaviour
{
    // Variables
    public GameObject attackerSpawner;
    public GameObject flyerSpawner;
    public GameObject rocketSpawner;

    public bool spawnAttacker = false;
    public bool spawnFlyer = false;
    public bool spawnRocket = false;

    private void Update()
    {
        if (spawnAttacker)
        {
            Instantiate(attackerSpawner, transform.position, Quaternion.identity);
            spawnAttacker = false;
        }

        if (spawnFlyer)
        {
            Instantiate(flyerSpawner, transform.position, Quaternion.identity);
            spawnFlyer = false;
        }

        if (spawnRocket)
        {
            Instantiate(rocketSpawner, transform.position, Quaternion.identity);
            spawnRocket = false;
        }
    }
}
