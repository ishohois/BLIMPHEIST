using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text enemiesKilledText; //Text som visas i GameOver(Mikita jobbat har sist)
    [SerializeField] private Text survivedTimeText; //Text som visas i GameOver
    [SerializeField] private Text obstaclesAvoidedText; //Text som visas i GameOver
    [SerializeField] private Text scoreText; //Text som visas i GameOver
    [SerializeField] private Timer timer; //Timer-objekt från Game-Hirearkin (har en timer som startas när scenen spelas)
    [SerializeField] private ObjectDeactivator objectDeactivator; //Object-Deactivator från Game-Hireakin (har en counter för inaktiverade/undvikna fiender)
    public int score;
    [SerializeField] private Text highScoreText;
    public UIScoreCounter scoreCounter; // ScoreCounter scriptet för att hämta antalet kills 
    public int currentHighScore;
    public string highScoreKey = "HighScore";

    public AudioSource deathSound; //Det ljud som spelas när man dör

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
        deathSound.pitch = Random.Range(0.6f, 0.9f);
        deathSound.Play();

        Debug.Log("Showing GameOver screen");
        gameObject.SetActive(true);
        survivedTimeText.text = "Time survived: " + timer.EndTimer();
        enemiesKilledText.text = "Enemies killed: " + scoreCounter.getKillsCount();
        obstaclesAvoidedText.text = "Obstacles avoided: " + objectDeactivator.GetObjectCounter();
        score = timer.GetTimeInSeconds() * objectDeactivator.GetObjectCounter(); //GetTimeInSeconds ger alla sekunder som räknats sedan scenen startats (ex. 94 sekunder); multipliceras sedan med objectDeactivators counter.
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
        Time.timeScale = 1f; //Start time again
    }
}
