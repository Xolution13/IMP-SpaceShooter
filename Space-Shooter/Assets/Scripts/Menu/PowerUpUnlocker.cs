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

    private void Awake()
    {
        extraLifeSymbol.GetComponent<Image>().color = Color.grey;
        destroyedEnemies = SaveManager.Instance.GetDestroyedEnemies(destroyedEnemies);
        extraLifeActualAmount.GetComponent<TextMeshProUGUI>().text = destroyedEnemies.ToString();
        ELneededAmount = Int32.Parse(extraLifeNeededAmount.GetComponent<TextMeshProUGUI>().text);

        if (destroyedEnemies >= ELneededAmount)
        {
            extraLifeSymbol.GetComponent<Image>().color = Color.green;
            destroyedEnemies = ELneededAmount;
            SaveManager.Instance.UnlockPowerUP(0);
        }
        Debug.Log(SaveManager.Instance.IsPowerUpUnlocked(0));
    }

}
