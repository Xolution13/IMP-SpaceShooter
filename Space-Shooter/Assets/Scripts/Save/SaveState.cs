public class SaveState
{
    // State of current highscore
    public int highScore = 0;

    // State of unlocked levels
    public int survivalCompletedLevel = 0;
    public int storyCompletedLevel = 0;
    public int pickUpAvailable = 0;

    // State for setting
    public float soundSetting = 1f;
    public float musicSetting = 1f;
    public bool useJoystick = false;
    public bool useAccelerometer = true;
}
