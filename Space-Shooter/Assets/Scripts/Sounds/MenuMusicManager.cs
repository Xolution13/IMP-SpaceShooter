using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    // Variables
    private float volume;
    private AudioSource musicSource;

    // Get the saved volume of the background music and set it as volume
    private void Start()
    {
        volume = SaveManager.Instance.GetMusicVolume(volume);
        volume /= 100;
        Debug.Log(volume);
        musicSource = GetComponent<AudioSource>();

        musicSource.volume = volume;
    }

    private void Update()
    {
        volume = SaveManager.Instance.GetMusicVolume(volume);
        volume /= 100;
        musicSource.volume = volume;
    }
}
