using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingSliderValue : MonoBehaviour
{
    // Variables
    public bool isSoundSetting = false;
    public bool isMusicSetting = false;
    public float volumeValue;
    private TextMeshProUGUI valueText;
    public GameObject slider;

    // Get the component and set it according to the save file
    private void Start()
    {
        valueText = GetComponent<TextMeshProUGUI>();
        if (isSoundSetting)
        {
            slider.GetComponent<Slider>().value = SaveManager.Instance.GetSoundVolume(volumeValue);
        }
        else if (isMusicSetting)
        {
            slider.GetComponent<Slider>().value = SaveManager.Instance.GetMusicVolume(volumeValue);
        }
    }

    // Call textUpdate when slider changes
    public void textUpdate(float value)
    {
        valueText.text = value.ToString();

        if (isSoundSetting)
        {
            SaveManager.Instance.SaveSoundVolume(value);
        }
        if (isMusicSetting)
        {
            SaveManager.Instance.SaveMusicVolume(value);
        }
    }
}
