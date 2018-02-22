using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Variables
    private float volume;
    private AudioSource musicSource;

    private void Start()
    {
        volume = SaveManager.Instance.GetMusicVolume(volume);
        musicSource = GetComponent<AudioSource>();

        musicSource.volume = volume;
    }
}
