using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Variables
    private float volume;
    private AudioSource musicSource;

    // Get the saved volume of the background music and set it as volume
    private void Start()
    {
        volume = SaveManager.Instance.GetMusicVolume(volume);
        volume /= 100;
        musicSource = GetComponent<AudioSource>();

        musicSource.volume = volume;
    }
}
