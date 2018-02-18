using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    // Variables
	public GameObject[] powerUps;
	public Vector3 spawnValues;
	private float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;
	private int randomPowerUP;

    // Start spawn-routine
	private void Start ()
    {
		StartCoroutine (waitSpawner ());
	}

	private void Update ()
    {
		spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
	}

	IEnumerator waitSpawner()
    {
		yield return new WaitForSeconds (startWait);

        // Select random power-up and spawn it after random time (between min and max value) - wait if power-up has spawned
        while (true)
        {
            randomPowerUP = Random.Range(0, powerUps.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.5f, Random.Range(-spawnValues.z, spawnValues.z));
            if (!stop)
            {
                Instantiate(powerUps[randomPowerUP], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                stop = true;
            }
            yield return new WaitForSeconds(spawnWait);
        }
	}
}
