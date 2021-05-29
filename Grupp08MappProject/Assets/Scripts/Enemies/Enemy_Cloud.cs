using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cloud : MonoBehaviour
{
    public GameObject lightning;
    private BoxCollider2D bx;

    [SerializeField] private float timer = 0f;
    [SerializeField] private float timeBefore = 1f;


    private void Start() {

        lightning.SetActive(false);
        bx = GetComponent<BoxCollider2D>();
        bx.enabled = false;
    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;

        if (timer >= timeBefore) {

            bx.enabled = true;
            lightning.SetActive(true);
        }
        if(timer >= timeBefore + 0.1f) {

            bx.enabled = false;
            lightning.SetActive(false);
            timer = 0f;
        }
    }


    private void OnTriggerStay2D(Collider2D collision) {
        
        if(collision.gameObject.CompareTag("Player") == true) {

            collision.gameObject.GetComponent<PlayerState>().UseBurst();
        }
    }
}
