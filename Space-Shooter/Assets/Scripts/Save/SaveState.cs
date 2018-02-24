public class SaveState
{
    // State of current highscore
    public int highScore = 0;
    public int destroyedEnemies = 0;
    public float timeAlive = 0;

    // State of unlocked levels
    public int survivalCompletedLevel = 0;
    public int powerUpUnlocked = 0;

    // State for setting
    public float soundSetting = 100;
    public float musicSetting = 100;
    public bool useJoystick = false;
    public bool useAccelerometer = true;
}
