using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MazeGameHandler : MonoBehaviour
{
    [Header("Timer Configuration")]
    [SerializeField] private Text timerText;
    [SerializeField] private float timerDuration;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerText(timer);
        }
        else
        {
            SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
            GameResult.instance.currentDate = 1;
            GameResult.instance.DDResult = 0;
            GameResult.instance.DSResult = 4;
            GameResult.instance.isSceneLoaded = true;
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
