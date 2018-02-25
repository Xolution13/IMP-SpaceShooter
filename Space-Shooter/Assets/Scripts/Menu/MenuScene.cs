using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f;

    public RectTransform menuContainer;

    public GameObject Survival;
    public Transform SurvivalButtonParent;
    public GameObject Endless;
    public GameObject Story;

    private int lastIndex = 0;
    private Vector3 desiredMenuPosition;

    private void Start()
    {
        // Grab the only CanvasGroup in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        // Start with a white/ black screen
        fadeGroup.alpha = 1;

        // Add button on-click events to levels
        InitLevel();

        // Set camera position to the focused menu
        SetCameraTo(Manager.Instance.menuFocus);
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

            // 4 = Survival Menu
            case 4:
                desiredMenuPosition = Vector3.right * 2560;
                break;

            // 5 = Endless Menu
            case 5:
                //desiredMenuPosition = Vector3.right * 2560;
                break;

            // 6 = Story Menu
            case 6:
                desiredMenuPosition = Vector3.right * 2560;
                break;

            //desiredMenuPosition = (Vector3.right * 2560) + (Vector3.down * 800);
        }
    }

    private void SetCameraTo(int menuIndex)
    {
        NavigateTo(menuIndex);
        menuContainer.anchoredPosition3D = desiredMenuPosition;
    }

    private void InitLevel()
    {
        // Add onClick-Event to every Button (children transform)
        int i = 0;
        foreach(Transform t in SurvivalButtonParent)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(() => OnLevelSelect(currentIndex));

            Image img = t.GetComponent<Image>();

            // Check if level is unlocked
            if (i <= SaveManager.Instance.state.survivalCompletedLevel)
            {
                // Level is unlocked - check if level is completed
                if (i == SaveManager.Instance.state.survivalCompletedLevel)
                {
                    // Level is not completed
                    img.color = Color.white;
                }
                else
                {
                    // Level is unlocked and completed
                    img.color = Color.green;
                }
            }
            else
            {
                // Level is not unlocked, button is disabled
                b.interactable = false;
                img.color = Color.grey;
            }

            i++;
        }
    }

    // Buttons
    public void OnStartClick()
    {
        NavigateTo(1);
        lastIndex = 0;
        Debug.Log("StartButton has been clicked");
    }

    public void OnProgressClick()
    {
        NavigateTo(2);
        lastIndex = 0;
        Debug.Log("ProgressButton has been clicked");
    }

    public void OnSettingsClick()
    {
        NavigateTo(3);
        lastIndex = 0;
        Debug.Log("SettingButton has been clicked");
    }

    public void OnSurvivalClick()
    {
        Survival.SetActive(true);
        Endless.SetActive(false);
        Story.SetActive(false);
        NavigateTo(4);
        lastIndex = 1;
        Debug.Log("SurvivaButton has been clicked");
    }

    private void OnLevelSelect(int currentIndex)
    {
        Manager.Instance.currentLevel = currentIndex;
        SceneManager.LoadScene("SurvivalLevel" + currentIndex);
        Debug.Log("Selecting level: " + currentIndex);
    }

    public void OnEndlessClick()
    {
        Endless.SetActive(true);
        Survival.SetActive(false);
        Story.SetActive(false);
        NavigateTo(5);
        lastIndex = 1;
        Debug.Log("EndlessButton has been clicked");
        SceneManager.LoadScene("Test");
    }

    public void OnStoryClick()
    {
        Story.SetActive(true);
        Survival.SetActive(false);
        Endless.SetActive(false);
        NavigateTo(6);
        lastIndex = 1;
        Debug.Log("StoryButton has been clicked");
    }

    public void OnExitClick()
    {
        NavigateTo(0);
        Application.Quit();
        Debug.Log("ExitButton has been clicked");
    }

    public void OnBackClick()
    {
        NavigateTo(lastIndex);

        // Save when exiting settings
        if (lastIndex == 0)
        {
            SaveManager.Instance.Save();
        }
        lastIndex = 0;
        Debug.Log("BackButton has been clicked");
    }

    public void OnPlayTestClick()
    {
        SceneManager.LoadScene("Test");
        Debug.Log("Loading Play Test");
    }
}
