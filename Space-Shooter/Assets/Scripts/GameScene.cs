using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float fadeInDuration = 2;
    private float fadeOutDuration = 2;
    public bool gameStarted;
    private bool endLevel;

    private void Start()
    {
        // Get the canvas group in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();
        
        // Set the fade to full opacity
        fadeGroup.alpha = 1;
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad <= fadeInDuration)
        {
            // Initial fade in
            fadeGroup.alpha = 1 - (Time.timeSinceLevelLoad / fadeInDuration);
        }

        // Check if the initial fade-in is completed and the game has not been started
        else if (!gameStarted)
        {
            // Ensure that the fade is completely gone
            fadeGroup.alpha = 0;
            gameStarted = true;
        }

        // Fade-out when level ends
        if (endLevel)
        {
            fadeGroup.alpha += Time.deltaTime;
            if (fadeGroup.alpha >= 1)
            {
                Debug.Log("Changing the scene!");
                ExitScene();
            }
        }
    }

    public void CompleteLevel()
    {
        // Complete the level and save the progress
        SaveManager.Instance.CompleteLevel(Manager.Instance.currentLevel);

        // Focus the level selection when returning to the menu scene - Case: 4 
        Manager.Instance.menuFocus = 4;

        endLevel = true;
    }

    public void LevelFailed()
    {
        // Focus the level selection when returning to the menu scene - Case: 4 
        Manager.Instance.menuFocus = 4;
        endLevel = true;
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
