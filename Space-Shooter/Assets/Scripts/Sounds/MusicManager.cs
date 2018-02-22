using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Variables
    private float volume;
    private AudioSource musicSource;

    private void Awake()
    {
        volume = SaveManager.Instance.GetMusicVolume(volume);
        //volume /= 100;
        Debug.Log(volume);
        musicSource = GetComponent<AudioSource>();

        musicSource.volume = volume;
    }
}
