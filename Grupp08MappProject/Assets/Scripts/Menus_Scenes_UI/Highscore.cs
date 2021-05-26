using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Highscore : MonoBehaviour
{
    private int currentHighScore;
    private string highScoreKey = "HighScore";
    [SerializeField] private TMP_Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentHighScore = PlayerPrefs.GetInt(highScoreKey);
        highScoreText.text = "" + currentHighScore;
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt(highScoreKey, 0);
        PlayerPrefs.Save();
        highScoreText.text = "0";
    }
}
