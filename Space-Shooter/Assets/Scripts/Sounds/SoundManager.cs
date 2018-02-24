using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Variables
    private float volume;
    private AudioSource soundSource;

    private void Start()
    {
        volume = SaveManager.Instance.GetSoundVolume(volume);
        volume /= 100;
        volume /= 10;
        soundSource = GetComponent<AudioSource>();

        soundSource.volume = volume;
    }
}
