using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text survivedTimeText;
    public Text obstaclesAvoidedText;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowGameOverScreen(int timeAlive, int obstaclesAvoided)
    {
        gameObject.SetActive(true);
        survivedTimeText.text = "Time survived: " + timeAlive.ToString() + " seconds"; //Kanske bör omvandla sekunder till minuter:sekunder om.
        obstaclesAvoidedText.text = "Obstacles avoided: " + obstaclesAvoided.ToString();
    }

    //public void RestartGame()
    //{
    //    Scenemanager.LoadScene("INSERT GAME SCENE HERE");
    //}

    //public void QuitGame()
    //{
    //    Scenemanager.LoadScene("INSERT MENU SCENE HERE");
    //}
}
