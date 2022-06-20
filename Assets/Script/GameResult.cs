using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public static GameResult instance;

    public int DSResult = 0;
    public int DDResult = 0;
    public int currentDate = 0;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Results");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
