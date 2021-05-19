using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird : MonoBehaviour, IKillable
{
    public ObjectDeactivator objectDeactivator;
    public bool isDead = false;
    public bool inactivateSprites;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float timeBeforeReset = 1f;

    private void Start() {
        inactivateSprites = false;
        objectDeactivator = GameObject.FindObjectOfType<ObjectDeactivator>();
    }

    private void Awake() {

        inactivateSprites = false;

        foreach (Transform child in transform) {

            child.gameObject.SetActive(true);
        }
    }

    private void Update() {

        if (inactivateSprites) {

            foreach (Transform child in transform) {

                if (child.GetComponent<ParticleSystem>() != null) {

                    child.GetComponent<ParticleSystem>().Play();

                    timer += Time.time;
                    if (timer >= timeBeforeReset) {

                        isDead = true;
                        timer = 0f;
                    }
                }
                else {

                    child.gameObject.SetActive(false);
                }
            }
        }
        
    }

    public void KillMe() {

        inactivateSprites = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<ParticleSystem>().Stop();

        if (isDead) {

            gameObject.transform.position = objectDeactivator.transform.position;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

        }

        // Död partiklar
        // Död ljudeffekt
        // Inaktivera grejer efter ovanstående har spelat klart

    }
}
