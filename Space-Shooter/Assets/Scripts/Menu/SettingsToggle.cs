using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class SettingsToggle : MonoBehaviour
{
    public void ChangeValue()
    {
        SaveManager.Instance.ChangeControl();
    }
}
