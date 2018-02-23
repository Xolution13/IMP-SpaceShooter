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

    public GameObject scoreUI;
    private Text scoreText;
    public GameObject timeUI;
    private Text timeText;

    private void Start()
    {
        scoreText = scoreUI.GetComponent<Text>();
        timeText = timeUI.GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = ("Score:@" + levelScore.ToString()).Replace("@", System.Environment.NewLine);
        timeText.text = (-Time.time).ToString();
        if (timeText.text.Length > 5)
        {
            timeText.text = timeText.text.Substring(0, 5);
        }
    }

    public void SaveGame()
    {

    }
}
