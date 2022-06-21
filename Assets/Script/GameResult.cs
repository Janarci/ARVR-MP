using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public static GameResult instance;

    public int DSResult = 0;
    public int DDResult = 0;
    public int currentDate = 0;

    public bool isSceneLoaded = false;

    public ChatUI chatUI;

    void Awake()
    {
        DSResult = 0;
        DDResult = 0;
        currentDate = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Results");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (isSceneLoaded)
        {
            chatUI.currentDate = currentDate;
            chatUI.currentDS = DSResult;
            chatUI.currentDD = DDResult;
            isSceneLoaded = true;
        }
    }

}
