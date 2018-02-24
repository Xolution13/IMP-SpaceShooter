using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    // Variables
    public int destroyedEnemies = 0;
    public int levelScore = 0;
    public int playerLifes = 0;
    public float timeAlive = 0;
    public bool gameOver;
    public bool countPlayTime = true;
    public float gameTime = 30;

    private GameScene gameSceneScript;
    public GameObject scoreUI;
    private Text scoreText;
    public GameObject timeUI;
    private Text timeText;



    private void Start()
    {
        scoreText = scoreUI.GetComponent<Text>();
        timeText = timeUI.GetComponent<Text>();
        gameSceneScript = FindObjectOfType<GameScene>().GetComponent<GameScene>();
    }

    private void Update()
    {
        if (gameSceneScript.gameStarted)
        {
            gameTime -= Time.deltaTime;

            scoreText.text = ("Score:@" + levelScore.ToString()).Replace("@", System.Environment.NewLine);
            timeText.text = gameTime.ToString();
            if (timeText.text.Length > 5)
            {
                timeText.text = timeText.text.Substring(0, 5);
            }

            // Check if the player is alive
            if (countPlayTime)
            {
                timeAlive += Time.deltaTime;
            }
        }
        SaveArchivements();
    }

    private void SaveArchivements()
    {
        if (gameOver)
        {
            SaveManager.Instance.SaveDestroyedEnemies(destroyedEnemies);
            SaveManager.Instance.SaveTimeAlive(timeAlive);
            SaveManager.Instance.Save();
            gameOver = false;
        }
        
    }
}
