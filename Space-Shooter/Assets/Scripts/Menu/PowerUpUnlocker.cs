using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PowerUpUnlocker : MonoBehaviour
{
    // Variables
    private int destroyedEnemies;
    private float timeAlive;

    public Transform extraLifeSymbol;
    public Transform extraLifeActualAmountMesh;
    public Transform extraLifeNeededAmountMesh;
    private int extraLifeNeededAmount;
    

    public Transform weaponSymbol;
    public Transform weaponActualAmountMesh;
    public Transform weaponNeededAmountMesh;
    private float weaponNeededAmount;

    public Transform speedSymbol;
    public Transform speedActualAmountMesh;
    public Transform speedNeededAmountMesh;
    private int speedNeededAmount;

    public Transform shieldSymbol;
    public Transform shieldActualAmountMesh;
    public Transform shieldNeededAmountMesh;
    private float shieldNeededAmount;

    public Transform shrinkSymbol;
    public Transform shrinkActualAmountMesh;
    public Transform shrinkNeededAmountMesh;
    private float shrinkNeededAmount;

    public Transform holeSymbol;
    public Transform holeActualAmountMesh;
    public Transform holeNeededAmountMesh;
    private float holeNeededAmount;

    private void Start()
    {
        /* Extra Life Power Up:
         * Set image to grey, load the destroyed enemy amount and show it in the text,
         * get the needed amount and check if the needed amount was reached,
         * if needed amount was reached - unlock extra-life power up (index 0) 
         */
        extraLifeSymbol.GetComponent<Image>().color = Color.grey;
        destroyedEnemies = SaveManager.Instance.GetDestroyedEnemies(destroyedEnemies);
        extraLifeActualAmountMesh.GetComponent<TextMeshProUGUI>().text = destroyedEnemies.ToString();
        extraLifeNeededAmount = Int32.Parse(extraLifeNeededAmountMesh.GetComponent<TextMeshProUGUI>().text);

        if (destroyedEnemies >= extraLifeNeededAmount)
        {
            extraLifeSymbol.GetComponent<Image>().color = Color.green;
            extraLifeActualAmountMesh.GetComponent<TextMeshProUGUI>().text = extraLifeNeededAmount.ToString();
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
        weaponActualAmountMesh.GetComponent<TextMeshProUGUI>().text = timeAlive.ToString();
        weaponNeededAmount = Int32.Parse(weaponNeededAmountMesh.GetComponent<TextMeshProUGUI>().text);

        if (timeAlive >= weaponNeededAmount)
        {
            weaponSymbol.GetComponent<Image>().color = Color.green;
            weaponActualAmountMesh.GetComponent<TextMeshProUGUI>().text = weaponNeededAmount.ToString();
            SaveManager.Instance.UnlockPowerUP(1);
        }
        Debug.Log(SaveManager.Instance.IsPowerUpUnlocked(1));

        /* Speed Power Up:
         * Set image to grey, show the loaded destroyed enemy amount in text,
         * get the needed amount and check if the needed amount was reached,
         * if needed amount was reached - unlock speed power up (index 2) 
         */
        speedSymbol.GetComponent<Image>().color = Color.grey;
        speedActualAmountMesh.GetComponent<TextMeshProUGUI>().text = destroyedEnemies.ToString();
        speedNeededAmount = Int32.Parse(speedNeededAmountMesh.GetComponent<TextMeshProUGUI>().text);

        if (destroyedEnemies >= speedNeededAmount)
        {
            speedSymbol.GetComponent<Image>().color = Color.green;
            speedActualAmountMesh.GetComponent<TextMeshProUGUI>().text = speedNeededAmount.ToString();
            SaveManager.Instance.UnlockPowerUP(2);
        }
        Debug.Log(SaveManager.Instance.IsPowerUpUnlocked(2));

        /* Shield Power Up:
         * Set image to grey, show the loaded player alive time in the text,
         * get the needed amount and check if the needed amount was reached,
         * if needed amount was reached - unlock shield power up (index 3) 
         */
        shieldSymbol.GetComponent<Image>().color = Color.grey;
        shieldActualAmountMesh.GetComponent<TextMeshProUGUI>().text = timeAlive.ToString();
        shieldNeededAmount = Int32.Parse(shieldNeededAmountMesh.GetComponent<TextMeshProUGUI>().text);

        if (timeAlive >= shieldNeededAmount)
        {
            shieldSymbol.GetComponent<Image>().color = Color.green;
            shieldActualAmountMesh.GetComponent<TextMeshProUGUI>().text = shieldNeededAmount.ToString();
            SaveManager.Instance.UnlockPowerUP(3);
        }
        Debug.Log(SaveManager.Instance.IsPowerUpUnlocked(3));

        /* Shrink Power Up:
         * Set image to grey, show the loaded player alive time in the text,
         * get the needed amount and check if the needed amount was reached,
         * if needed amount was reached - unlock shrink power up (index 4) 
         */
        shrinkSymbol.GetComponent<Image>().color = Color.grey;
        shrinkActualAmountMesh.GetComponent<TextMeshProUGUI>().text = timeAlive.ToString(); //## create Unlock Item for finishing Survival Lvl 12 ## 
        shrinkNeededAmount = Int32.Parse(shrinkNeededAmountMesh.GetComponent<TextMeshProUGUI>().text);

        if (timeAlive >= shieldNeededAmount)
        {
            shrinkSymbol.GetComponent<Image>().color = Color.green;
            shrinkActualAmountMesh.GetComponent<TextMeshProUGUI>().text = shrinkNeededAmount.ToString();
            SaveManager.Instance.UnlockPowerUP(4);
        }
        Debug.Log(SaveManager.Instance.IsPowerUpUnlocked(4));

        /* Black Hole Power Up:
         * Set image to grey, show the loaded player alive time in the text,
         * get the needed amount and check if the needed amount was reached,
         * if needed amount was reached - unlock black hole power up (index 5) 
         */
        holeSymbol.GetComponent<Image>().color = Color.grey;
        holeActualAmountMesh.GetComponent<TextMeshProUGUI>().text = timeAlive.ToString(); //## create Unlock Item for picked up Power Ups ## 
        holeNeededAmount = Int32.Parse(holeNeededAmountMesh.GetComponent<TextMeshProUGUI>().text);

        if (timeAlive >= holeNeededAmount)
        {
            holeSymbol.GetComponent<Image>().color = Color.green;
            holeActualAmountMesh.GetComponent<TextMeshProUGUI>().text = holeNeededAmount.ToString();
            SaveManager.Instance.UnlockPowerUP(5);
        }
        Debug.Log(SaveManager.Instance.IsPowerUpUnlocked(5));
    }

}
