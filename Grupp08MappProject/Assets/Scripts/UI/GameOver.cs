using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text enemiesKilledText; //Text som visas i GameOver(Mikita jobbat har sist)
    [SerializeField] private TMP_Text survivedTimeText; //Text som visas i GameOver
    [SerializeField] private TMP_Text obstaclesAvoidedText; //Text som visas i GameOver
    [SerializeField] private TMP_Text scoreText; //Text som visas i GameOver
    [SerializeField] private Timer timer; //Timer-objekt från Game-Hirearkin (har en timer som startas när scenen spelas)
    [SerializeField] private ObjectDeactivator objectDeactivator; //Object-Deactivator från Game-Hireakin (har en counter för inaktiverade/undvikna fiender)
    public int score;
    [SerializeField] private TMP_Text highScoreText;
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
        obstaclesAvoidedText.text = "Obstacles avoided: " + objectDeactivator.GetObjectCounter();
        enemiesKilledText.text = "Enemies killed: " + scoreCounter.getKillsCount(); // Enemies killed utskriftet
        score = scoreCounter.getScore();
        scoreText.text = "Score: " + score;
        Time.timeScale = 0f; //Stops time
        if (currentHighScore < score)
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
            currentHighScore = score;
        }
        highScoreText.text = "Highscore: " + currentHighScore;
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
