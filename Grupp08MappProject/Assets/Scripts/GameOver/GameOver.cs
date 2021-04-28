using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text survivedTimeText;
    [SerializeField] private Text obstaclesAvoidedText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Timer timer;
    [SerializeField] private ObjectDeactivator objectDeactivator;
    public int score;
    [SerializeField] private Text highScoreText;
    public int currentHighScore;
    public string highScoreKey = "HighScore";

    void Start()
    {
        if (PlayerPrefs.HasKey(highScoreKey))
        {
            currentHighScore = PlayerPrefs.GetInt(highScoreKey);
        }
        gameObject.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        Debug.Log("Showing GameOver screen");
        gameObject.SetActive(true);
        survivedTimeText.text = "Time survived: " + timer.EndTimer();
        obstaclesAvoidedText.text = "Obstacles avoided: " + objectDeactivator.GetObjectCounter();
        score = timer.GetTimeInSeconds() * objectDeactivator.GetObjectCounter();
        scoreText.text = "Score: " + score;
        Time.timeScale = 0f; //Stops time
        if (currentHighScore < score)
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
            currentHighScore = score;
        }
        highScoreText.text = "HighScore: " + currentHighScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f; //Start time again
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
