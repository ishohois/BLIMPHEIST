using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// SCORE IS DETERMINED AS: score = (timer.GetTimeInSeconds() * (objectDeactivator.GetObjectCounter() + killsCount) + killsCount * 100) / 2


public class UIScoreCounter : MonoBehaviour
{

    [SerializeField] private int killsCount = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Timer timer;
    [SerializeField] private ObjectDeactivator objectDeactivator;
    public int score;
   


    // Update is called once per frame
    void Update() {

        score = (timer.GetTimeInSeconds() * (objectDeactivator.GetObjectCounter() + killsCount) + killsCount * 100) / 2;
        scoreText.text = "" + score;

    }

    public void IncrementKillsCount() {

        killsCount++;
    }
    
    public int getKillsCount() {

        return killsCount;
    }

    public int getScore()
    {

        return score;
    }
}
