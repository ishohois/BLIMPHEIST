using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// SCORE IS DETERMINED AS: score = timer.GetTimeInSeconds() * objectDeactivator.GetObjectCounter();



public class UIScoreCounter : MonoBehaviour
{

    // [SerializeField] private Text survivedTimeText;
    // [SerializeField] private Text obstaclesAvoidedText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Timer timer;
    [SerializeField] private ObjectDeactivator objectDeactivator;
    public int score;
   



    // Start is called before the first frame update
    //void Start() {
    //    //score = GetComponent<text>;

    //}



    // Update is called once per frame
    void Update() {
        // score.text = scoreValue; 

        score = timer.GetTimeInSeconds() * objectDeactivator.GetObjectCounter();
        scoreText.text = "" + score;

    }
    
}
