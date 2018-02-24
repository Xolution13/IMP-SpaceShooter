using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    // Variables
    public GameObject extraLifePowerUp;
    public GameObject weaponPowerUp;
    public GameObject speedPowerUp;
    public GameObject shieldPowerUp;
    public GameObject shrinkPowerUp;
    public GameObject blackHolePowerUp;
    private List<GameObject> unlockedPowerUpList = new List<GameObject>();
    private GameObject[] unlockedPowerUps;
	public Vector3 spawnValues;
	private float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public int startWait;
	public bool stop;
	private int randomPowerUP;
    private bool noPowerUps = false;

    // Check if any power ups are unlocked and only then start the spawner
	private void Start ()
    {
        CheckForPowerUps();
        if (!noPowerUps)
        {
            StartCoroutine(waitSpawner());
        }
	}

	private void Update ()
    {
		spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
	}

    private void CheckForPowerUps()
    {
        // Check if the extra life power up is unlocked and add it to array
        if (SaveManager.Instance.IsPowerUpUnlocked(0))
        {
            unlockedPowerUpList.Add(extraLifePowerUp);
        }
        // Check if the weapon power up is unlocked and add it to array
        else if (SaveManager.Instance.IsPowerUpUnlocked(1))
        {
            unlockedPowerUpList.Add(weaponPowerUp);
        }
        // Check if the speed power up is unlocked and add it to array
        else if (SaveManager.Instance.IsPowerUpUnlocked(2))
        {
            unlockedPowerUpList.Add(speedPowerUp);
        }
        // Check if the shield power up is unlocked and add it to array
        else if (SaveManager.Instance.IsPowerUpUnlocked(3))
        {
            unlockedPowerUpList.Add(shieldPowerUp);
        }
        // Check if the shrink power up is unlocked and add it to array
        else if (SaveManager.Instance.IsPowerUpUnlocked(4))
        {
            unlockedPowerUpList.Add(shrinkPowerUp);
        }
        // Check if the black-hole power up is unlocked and add it to array
        else if (SaveManager.Instance.IsPowerUpUnlocked(5))
        {
            unlockedPowerUpList.Add(blackHolePowerUp);
        }
        else
        {
            Debug.Log("No power-ups unlocked!");
            noPowerUps = true;
        }

        // Convert the list to the array
        unlockedPowerUps = unlockedPowerUpList.ToArray();
        for (int i = 0; i < unlockedPowerUps.Length; i++)
        {
            Debug.Log("Spawning Power-Ups: " + unlockedPowerUps[i]);
        }
    }

	IEnumerator waitSpawner()
    {
		yield return new WaitForSeconds (startWait);

        // Select random power-up and spawn it after random time (between min and max value) - wait if power-up has spawned
        while (true)
        {
            randomPowerUP = Random.Range(0, unlockedPowerUps.Length + 1);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0.5f, Random.Range(-spawnValues.z, spawnValues.z));
            if (!stop)
            {
                Instantiate(unlockedPowerUps[randomPowerUP], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                stop = true;
            }
            yield return new WaitForSeconds(spawnWait);
        }
	}
}
