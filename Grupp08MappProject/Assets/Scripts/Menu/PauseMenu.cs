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
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseButton.gameObject.SetActive(true);
        burstButton.gameObject.SetActive(true);
    }

    public void Pause()
    {
        if(pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
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
            Time.timeScale = 0f;
            GameIsPaused = true;
            pauseButton.gameObject.SetActive(false);
        }

    }
}
