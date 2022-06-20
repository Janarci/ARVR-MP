using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public static GameResult instance;

    private int DSResult;
    private int DDResult;

    public int DSResult1 { get => DSResult; set => DSResult = value; }
    public int DDResult1 { get => DDResult; set => DDResult = value; }

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
