using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoleGameHandler : MonoBehaviour
{
    [Header("Timer Configuration")]
    [SerializeField] private Text timerText;
    [SerializeField] private float eventTimer = 120.0f;

    [Header("Score Configuration")]
    [SerializeField] private Text currentScoreText;
    public int currentScore = 0;
    [SerializeField] private Text highScoreText;
    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
        currentScoreText.text = "Score: " + currentScore.ToString();
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
                SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
                GameResult.instance.currentDate = 3;
                GameResult.instance.DDResult = 0;
                GameResult.instance.DSResult = 2;
                AffectionLevelManager.instance.AddAffectionOnEvent(10);
                GameResult.instance.isSceneLoaded = true;
            }
            else
            {
                //insert lose scene here
                SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
                GameResult.instance.currentDate = 3;
                GameResult.instance.DDResult = 0;
                GameResult.instance.DSResult = 3;
                GameResult.instance.isSceneLoaded = true;
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void UpdateTimerText(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void UpdateCurrentScoreText(string name)
    {
        if ((string.Equals(name, "Mole1")) || (string.Equals(name, "Mole3")))
        {
            currentScore += 20;
            currentScoreText.text = "Score: " + currentScore.ToString();
        }
        else if ((string.Equals(name, "Mole2")) || (string.Equals(name, "Mole4")))
        {
            currentScore += 40;
            currentScoreText.text = "Score: " + currentScore.ToString();
        }
        else
        {
            currentScore += 60;
            currentScoreText.text = "Score: " + currentScore.ToString();
        }
    }
}