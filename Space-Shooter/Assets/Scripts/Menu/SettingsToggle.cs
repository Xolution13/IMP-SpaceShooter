using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class SettingsToggle : MonoBehaviour
{
    public GameObject ToggleAccelerometer;
    public GameObject ToggleJoystick;

    private void Start()
    {
        ToggleAccelerometer.GetComponent<Toggle>().on = false;
        ToggleJoystick.GetComponent<Toggle>().on = true;
    }
}
