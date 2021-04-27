using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text survivedTimeText;
    public Text obstaclesAvoidedText;
    public GameController gameController;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowGameOverScreen() //int timeAlive, int obstaclesAvoided
    {
        Debug.Log("Showing GameOver screen");
        gameObject.SetActive(true);
        survivedTimeText.text = "Time survived: " + gameController.EndTimer();
        obstaclesAvoidedText.text = "Obstacles avoided: "; //+ obstaclesAvoided.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
