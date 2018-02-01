using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f;

    private void Start()
    {
        // Grab the only CanvasGroup in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        // Start with a white screen
        fadeGroup.alpha = 1;
    }

    private void Update()
    {
        // Fade-in
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
    }

    // Buttons
    public void OnPlayClick()
    {
        Debug.Log("PlayButton has been clicked");
    }

    public void OnShopClick()
    {
        Debug.Log("ShopButton has been clicked");
    }

    public void OnShopBackClick()
    {
        Debug.Log("ShopBackButton has been clicked");
    }
	
}
