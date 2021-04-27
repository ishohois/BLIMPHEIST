using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System; //timer

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool gameOver = false;
    public float scrollSpeed; 

    public float maxSpeed;

    bool timerActive; //Timer
    float currentTime; //Timer
    string endTime; //Timer

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        timerActive = true; //timer
        currentTime = 0; //timer
    }

    void Update()
    {
        if (gameOver == true && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (timerActive == true) //Timer
        {
            currentTime = currentTime + Time.deltaTime;
            //Debug.Log("Timer running");
        }
    }

    public void PlaySound(AudioClip playme)
    {
        GetComponent<AudioSource>().clip = playme;
        GetComponent<AudioSource>().PlayOneShot(playme);
    }

    public String EndTimer() //Timer
    {
        timerActive = false;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        endTime = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        return endTime;
    }
}
