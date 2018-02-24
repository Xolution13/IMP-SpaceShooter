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

    private void Start()
    {
        /* Extra Life Power Up:
         * Set image to grey, load the destroyed enemy amount and show it in the text,
         * get the needed amount and check if the needed amount was reached,
         * if needed amount was reached - unlock extra-life power up (index 0) */
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
    }

}
