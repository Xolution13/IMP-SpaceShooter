using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { set; get; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public int currentLevel = 0;        // Used when changing from menu to game scene
    public int menuFocus = 0;           // used when entering the menu scene (to know what menu should be shown)
}
