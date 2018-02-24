using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PowerUpUnlocker : MonoBehaviour
{
    // Variables
    public Transform extraLifeSymbol;
    public Transform extraLifeActualAmount;
    public Transform extraLifeNeededAmount;
    private int ELneededAmount;
    private int destroyedEnemies;

    public Transform weaponSymbol;
    public Transform weaponActualAmount;
    public Transform weaponNeededAmount;
    private float WPneededAmount;
    private float timeAlive;

    public Transform speedSymbol;
    public Transform speedActualAmount;
    public Transform speedNeededAmount;
    private int SUneededAmount;

    private void Start()
    {
        /* Extra Life Power Up:
         * Set image to grey, load the destroyed enemy amount and show it in the text,
         * get the needed amount and check if the needed amount was reached,
         * if needed amount was reached - unlock extra-life power up (index 0) 
         */
        extraLifeSymbol.GetComponent<Image>().color = Color.grey;
        destroyedEnemies = SaveManager.Instance.GetDestroyedEnemies(destroyedEnemies);
        extraLifeActualAmount.GetComponent<TextMeshProUGUI>().text = destroyedEnemies.ToString();
        ELneededAmount = Int32.Parse(extraLifeNeededAmount.GetComponent<TextMeshProUGUI>().text);

        if (destroyedEnemies >= ELneededAmount)
        {
            extraLifeSymbol.GetComponent<Image>().color = Color.green;
            extraLifeActualAmount.GetComponent<TextMeshProUGUI>().text = ELneededAmount.ToString();
            SaveManager.Instance.UnlockPowerUP(0);
        }
        Debug.Log(SaveManager.Instance.IsPowerUpUnlocked(0));

        /* Weapon Power Up:
         * Set image to grey, load the player alive time and show it in the text,
         * get the needed amount and check if the needed amount was reached,
         * if needed amount was reached - unlock weapon power up (index 1) 
         */
        weaponSymbol.GetComponent<Image>().color = Color.grey;
        timeAlive = SaveManager.Instance.GetTimeAlive(timeAlive);
        timeAlive = Mathf.CeilToInt(timeAlive);
        weaponActualAmount.GetComponent<TextMeshProUGUI>().text = timeAlive.ToString();
        WPneededAmount = Int32.Parse(weaponNeededAmount.GetComponent<TextMeshProUGUI>().text);

        if (timeAlive >= WPneededAmount)
        {
            weaponSymbol.GetComponent<Image>().color = Color.green;
            weaponActualAmount.GetComponent<TextMeshProUGUI>().text = WPneededAmount.ToString();
            SaveManager.Instance.UnlockPowerUP(1);
        }
        Debug.Log(SaveManager.Instance.IsPowerUpUnlocked(1));

        /* Speed Power Up:
         * Set image to grey, show the loaded destroyed enemy amount in text,
         * get the needed amount and check if the needed amount was reached,
         * if needed amount was reached - unlock speed power up (index 2) 
         */
        speedSymbol.GetComponent<Image>().color = Color.grey;
        speedActualAmount.GetComponent<TextMeshProUGUI>().text = destroyedEnemies.ToString();
        SUneededAmount = Int32.Parse(speedNeededAmount.GetComponent<TextMeshProUGUI>().text);

        if (destroyedEnemies >= SUneededAmount)
        {
            speedSymbol.GetComponent<Image>().color = Color.green;
            speedActualAmount.GetComponent<TextMeshProUGUI>().text = SUneededAmount.ToString();
            SaveManager.Instance.UnlockPowerUP(2);
        }
        Debug.Log(SaveManager.Instance.IsPowerUpUnlocked(2));
    }

}
