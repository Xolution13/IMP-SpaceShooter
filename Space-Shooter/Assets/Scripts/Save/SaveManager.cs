using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
    }

    // Save the whole state of this script to the player pref
    public void Save()
    {
       // PlayerPrefs.SetString("save",);
    }

    // Load the previous saved state from player prefs
    public void Load()
    {
        // Check if there is a save
        if (PlayerPrefs.HasKey("save"))
        {
            //state = 
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save was found. Creating a new one.");
        }
    }
}
