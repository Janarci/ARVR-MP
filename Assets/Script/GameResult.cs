using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (instance == null)
            instance = this;
        else
        {
            //Debug.LogError("Multiple instance of AffectionLevelManager Exists");

            GameObject[] objs = GameObject.FindGameObjectsWithTag("Results");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

        }

        DontDestroyOnLoad(this.gameObject);

        DSResult = 0;
        DDResult = 0;
        currentDate = 0;
    }

    private void Update()
    {
        if (isSceneLoaded)
        {
            chatUI.currentDate = currentDate;
            chatUI.currentDS = DSResult;
            chatUI.currentDD = DDResult;
            chatUI.ChatBoxParent.SetActive(true);
            chatUI.isOnLoad = false;
            isSceneLoaded = false;
        }
    }

    public void onMazeWin()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        currentDate = 1;
        DDResult = 0;
        DSResult = 3;
        isSceneLoaded = true;
        AffectionLevelManager.instance.AddAffectionOnEvent(10);
    }

    public void onMazeLose()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        currentDate = 1;
        DDResult = 0;
        DSResult = 4;
        isSceneLoaded = true;
    }

    public void onMoleWin()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        currentDate = 3;
        DDResult = 0;
        DSResult = 2;
        AffectionLevelManager.instance.AddAffectionOnEvent(10);
        isSceneLoaded = true;
    }

    public void onMoleLose()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        currentDate = 3;
        DDResult = 0;
        DSResult = 3;
        isSceneLoaded = true;
    }

}
