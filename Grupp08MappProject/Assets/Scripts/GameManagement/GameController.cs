using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool gameOver = false;
    public float scrollSpeed; 

    public float maxSpeed;

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
    }

    void Update()
    {
        float target = -15.0f;
        float delta = target + scrollSpeed;
        delta *= Time.deltaTime;
        scrollSpeed += delta / 9000;

        if (gameOver == true && Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlaySound(AudioClip playme)
    {
        GetComponent<AudioSource>().clip = playme;
        GetComponent<AudioSource>().PlayOneShot(playme);
    }
}
