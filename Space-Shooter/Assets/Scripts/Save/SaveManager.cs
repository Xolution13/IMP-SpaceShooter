using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // Variables
    public static SaveManager Instance { set; get; }
    public SaveState state;

    // Load previous save and keep this GameObject alive for references
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(SaveDeserializer.Serialize<SaveState>(state));
        Debug.Log(state.soundSetting);
        Debug.Log(state.musicSetting);
    }

    // Save the whole state of this script to the player pref
    public void Save()
    {
        PlayerPrefs.SetString("save", SaveDeserializer.Serialize<SaveState>(state));
        Debug.Log("Game was saved");
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

    // Get the saved music volume 
    public float GetMusicVolume(float volume)
    {
        volume = state.musicSetting;
        return volume;
    }

    // Get the saved sound volume
    public float GetSoundVolume(float volume)
    {
        volume = state.soundSetting;
        return volume;
    }

    // Save the music volume to SaveState
    public void SaveMusicVolume(float volume)
    {
        state.musicSetting = volume;
        volume *= 100;
    }

    // Save the sound volume to SaveState
    public void SaveSoundVolume(float volume)
    {
        state.soundSetting = volume;
        volume *= 100;
    }

    // Get the saved control state
    public bool GetControlStatus(bool status)
    {
        if (state.useAccelerometer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Change the control state when toggle changes
    public void ChangeControl()
    {
        if (!state.useJoystick)
        {
            state.useAccelerometer = false;
            state.useJoystick = true;
        }
        else if (!state.useAccelerometer)
        {
            state.useJoystick = false;
            state.useAccelerometer = true;
        }
    }

    // Complete Level
    public void CompleteLevel(int index)
    {
        // Check if the level is the current active level
        if (state.survivalCompletedLevel == index)
        {
            state.survivalCompletedLevel++;
            Save();
        }
    }
}
