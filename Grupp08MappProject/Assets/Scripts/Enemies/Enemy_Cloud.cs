using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cloud : MonoBehaviour
{

    public PlayerState playerState;
    public GameObject lightning;

    [SerializeField] private bool hit = false;
    [SerializeField] private bool colliding;

    [SerializeField] private float timer = 0f;
    [SerializeField] private float timeBefore = 1f;


    private void Start() {

        lightning.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;

        if (timer >= timeBefore) {

            hit = true;
            lightning.SetActive(true);
        }
        if(timer >= timeBefore + 0.2f) {

            hit = false;
            lightning.SetActive(false);
            timer = 0f;
        }
    }


    private void OnTriggerStay2D(Collider2D collision) {
        
        if(hit == true && collision.gameObject.CompareTag("Player") == true) {

            playerState.UseBurst();
        }
    }
}
