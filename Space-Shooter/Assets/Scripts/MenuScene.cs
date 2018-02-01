using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f;

    public RectTransform menuContainer;

    private Vector3 desiredMenuPosition;

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

        // Menu navigation (smooth)
        menuContainer.anchoredPosition3D = Vector3.Lerp(menuContainer.anchoredPosition3D, desiredMenuPosition, 0.1f);
    }

    private void NavigateTo(int menuIndex)
    {
        switch (menuIndex)
        {
            // 0 && default case = Main Menu
            default:
            case 0:
                desiredMenuPosition = Vector3.zero;
                break;
            // 1 = Play Menu
            case 1:
                desiredMenuPosition = Vector3.right * 1280;
                break;
            // 2 = Shop Menu
            case 2:
                desiredMenuPosition = Vector3.left * 1280;
                break;
            // 3 = Setting Menu
            case 3:
                desiredMenuPosition = Vector3.up * 800;
                break;

        }
    }

    // Buttons
    public void OnPlayClick()
    {
        NavigateTo(1);
        Debug.Log("PlayButton has been clicked");
    }

    public void OnShopClick()
    {
        NavigateTo(2);
        Debug.Log("ShopButton has been clicked");
    }

    public void OnSettingsClick()
    {
        NavigateTo(3);
        Debug.Log("SettingButton has been clicked");
    }

    public void OnBackClick()
    {
        NavigateTo(0);
        Debug.Log("BackButton has been clicked");
    }
	
}
