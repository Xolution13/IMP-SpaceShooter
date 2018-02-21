using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsToggle : MonoBehaviour
{
    // Variables
    public GameObject accelerometerToggle;
    public GameObject joystickToggle;
    private Toggle accelerometerStatus;
    private Toggle joystickStatus;

    private void Start()
    {
        // Get the Toggle-Components
        accelerometerStatus = accelerometerToggle.GetComponent<Toggle>();
        joystickStatus = joystickToggle.GetComponent<Toggle>();
        
        // Set the status according to the save file
        if (SaveManager.Instance.GetControlStatus(true))
        {
            accelerometerStatus.isOn = true;
            joystickStatus.isOn = false;
        }
        else
        {
            accelerometerStatus.isOn = false;
            joystickStatus.isOn = true;
        }
    }

    // Call ChangeValue when toggle status changes
    public void ChangeValue()
    {
        SaveManager.Instance.ChangeControl();
    }
}
