using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuPanel;
    public GameObject settingsMenuPanel;
    public Button pauseButton;
    public Button burstButton;

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; //time start
        GameIsPaused = false;
        AudioListener.pause = false;

        GameObject blimpObject = GameObject.Find("Blimp(NewAnimation)"); //Måste vara exakt det namnet som har Blimp_Movement scriptets
        blimpObject.GetComponent<Blimp_Movement>().enabled = true; //Enable Blimp_Moement script when game resumes so player can move again (and flyingsound plays again)

        pauseButton.gameObject.SetActive(true);
        burstButton.gameObject.SetActive(true);
    }

    public void Pause()
    {
        if(pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f; //time stop
            GameIsPaused = true;
            AudioListener.pause = true;

            GameObject blimpObject = GameObject.Find("Blimp(NewAnimation)"); //Måste vara exakt det namnet som har Blimp_Movement scriptet
            blimpObject.GetComponent<Blimp_Movement>().enabled = false; //Disable Blimp_Movement script so flyingSound doesn't play when game is paused

            pauseButton.gameObject.SetActive(false);
            burstButton.gameObject.SetActive(false);
            settingsMenuPanel.SetActive(false);
        }
    }

    public void LoadMenu()
    {
        if(settingsMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
            burstButton.gameObject.SetActive(false);
            settingsMenuPanel.SetActive(true);
            Time.timeScale = 0f; //time stop
            //AudioListener.pause = false;
            GameIsPaused = true;
            pauseButton.gameObject.SetActive(false);
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f; //Start time again
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f; //Start time again
    }
}
