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

        Debug.Log(SaveDeserializer.Serialize<SaveState>(state));
    }

    // Save the whole state of this script to the player pref
    public void Save()
    {
        PlayerPrefs.SetString("save", SaveDeserializer.Serialize<SaveState>(state));
    }

    // Load the previous saved state from player prefs
    public void Load()
    {
        // Check if there is a save
        if (PlayerPrefs.HasKey("save"))
        {
            state = SaveDeserializer.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save was found. Creating a new one.");
        }
    }

    //Check if the survival-level was completed
    public bool IsSurvivalCompleted(int index)
    {
        // Check if the bit is set, if so the survival-level is completed
        return (state.survivalCompletedLevel & (1 << index)) != 0;
    }

    // Check if the story level was completed
    public bool IsStoryCompleted(int index)
    {
        // Check if the bit is set, if so the survival-level is completed
        return (state.storyCompletedLevel & (1 << index)) != 0;
    }

    // Unlock the survival level
    public void UnlockSurvivalLevel(int index)
    {
        state.survivalCompletedLevel |= 1 << index;
    }

    // Unlock the story level
    public void UnlockStoryLevel(int index)
    {
        state.storyCompletedLevel |= 1 << index;
    }

}
