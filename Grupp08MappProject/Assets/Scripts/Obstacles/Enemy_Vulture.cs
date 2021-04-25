using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Vulture : MonoBehaviour
{
    public PlayerState playerState;

    [SerializeField] private bool colliding;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float timeBeforeReset = 1f;

    // Update is called once per frame
    void Update()
    {
        if (colliding) {

            timer += Time.deltaTime;

            if(timer >= timeBeforeReset) {

                playerState.UseBurst();
                timer = 0f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {

            colliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {

            colliding = false;
            timer = 0f;
        }
    }
}
