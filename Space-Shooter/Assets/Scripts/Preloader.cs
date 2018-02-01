using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumLogoTime = 3.0f; // Minimum time of that scene

    private void Start ()
    {
        // Grab the only CanvasGroup in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        // Start with a black screen
        fadeGroup.alpha = 1;

        //Pre load the game
        // To-Do

        // Get a timestamp of the completion time
        // if loadtime is fast, give it a small time to show logo
        if (Time.time < minimumLogoTime)
        {
            loadTime = minimumLogoTime;
        }
        else
        {
            loadTime = Time.time;
        }
    }

    private void Update()
    {
        // Fade-in
        if (Time.time < minimumLogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }

        // Fade-out
        if (Time.time > minimumLogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimumLogoTime;
            if (fadeGroup.alpha >= 1)
            {
                Debug.Log("Changing the scene!");
            }
        }
    }

}
