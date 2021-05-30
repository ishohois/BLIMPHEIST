using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Vulture : MonoBehaviour
{
    private PlayerState playerState;
    private AudioSource audio;

    [SerializeField] private bool colliding;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float timeBeforeReset = 1f;

    private void Start() {
        audio = GameObject.Find("Audio Source- VultureShockSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {

            timer += Time.deltaTime;

            if (timer >= timeBeforeReset)
            {

                if (playerState != null)
                {
                    audio.pitch = UnityEngine.Random.Range(0.7f, 1f);
                    audio.Play();
                    playerState.UseBurst();
                }
                timer = 0f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            playerState = collision.GetComponent<PlayerState>();
            colliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") == true)
        {
            playerState = null;
            colliding = false;
            timer = 0f;
        }
    }
}
