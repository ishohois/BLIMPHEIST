using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// SCORE IS DETERMINED AS: score = timer.GetTimeInSeconds() * objectDeactivator.GetObjectCounter();



public class UIScoreCounter : MonoBehaviour
{

    // [SerializeField] private Text survivedTimeText;
    // [SerializeField] private Text obstaclesAvoidedText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Timer timer;
    [SerializeField] private ObjectDeactivator objectDeactivator;
    public int score;

    //public static int scoreValue = 0;
    //Text score;


    //Scorecounter as shown top right
    void ActiveScore() {


        score = timer.GetTimeInSeconds()* objectDeactivator.GetObjectCounter();

}


    /* Start is called before the first frame update
    void Start()
    {
        //score = GetComponent<text>;
        
    }

    // Update is called once per frame
    void Update()
    {
       // score.text = scoreValue; 
    }
    */
}
