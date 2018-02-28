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

    // Reset the save
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }

    // Check if the survival-level was completed
    public bool IsSurvivalCompleted(int index)
    {
        // Check if the bit is set, if so the survival-level is completed
        return (state.survivalCompletedLevel & (1 << index)) != 0;
    }

    // Check if the powerUp was completed
    public bool IsPowerUpUnlocked(int index)
    {
        // Check if the bit is set, if so the survival-level is completed
        return (state.powerUpUnlocked & (1 << index)) != 0;
    } 

    // Unlock the survival level
    public void UnlockSurvivalLevel(int index)
    {
        state.survivalCompletedLevel |= 1 << index;
    }

    // Unlock the powerUp
    public void UnlockPowerUP(int index)
    {
        state.powerUpUnlocked |= 1 << index;
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

    // Save the calibration
    public void CalibrateAccelerometer(Matrix4x4 calibrationMatrix)
    {
        Vector3 originalTilt = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), originalTilt);

        // Create identity matrix and rotate our matrix to match up with down vec
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));

        // Get the inverse of the matrix
        calibrationMatrix = matrix.inverse;
        state.calibrationMatrix = calibrationMatrix;
        Debug.Log("Accelerometer was calibrated");
    }

    // Get the calibration
    public Matrix4x4 GetAccelerometerCalibration(Matrix4x4 calibrationMatrix)
    {
        calibrationMatrix = state.calibrationMatrix;
        return calibrationMatrix;
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

    // Save destroyed enemies
    public void SaveDestroyedEnemies(int destroyedEnemies)
    {
        state.destroyedEnemies += destroyedEnemies;
    }

    // Get destroyed enemies for menu
    public int GetDestroyedEnemies(int destroyedEnemies)
    {
        destroyedEnemies = state.destroyedEnemies;
        return destroyedEnemies;
    }

    // Save player alive time
    public void SaveTimeAlive(float timeAlive)
    {
        if (state.timeAlive <= timeAlive)
        {
            state.timeAlive = timeAlive;
        }
    }

    // Get player alive time
    public float GetTimeAlive(float timeAlive)
    {
        timeAlive = state.timeAlive;
        return timeAlive;
    }
}
