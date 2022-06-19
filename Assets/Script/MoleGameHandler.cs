using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleGameHandler : MonoBehaviour
{
    public int currentScore = 0;
    public int highScore = 1064;
    [SerializeField] private float eventTimer = 120.0f;
    [SerializeField] private Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (eventTimer > 0)
        {
            eventTimer -= Time.deltaTime;
            UpdateTimerText(eventTimer);
        }
        else
        {
            if (currentScore > highScore)
            {
                //insert win scene here
            }
            else
            {
                //insert lose scene here
            }
        }
    }

    private void UpdateTimerText(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
