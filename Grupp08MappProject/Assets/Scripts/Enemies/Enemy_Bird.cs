using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird : MonoBehaviour, IKillable
{
    public ObjectDeactivator objectDeactivator;
    public bool isDead = false;

    private void Start() {

        objectDeactivator = GameObject.FindObjectOfType<ObjectDeactivator>();
    }

    private void Awake() {

        foreach (Transform child in transform) {

            child.gameObject.SetActive(true);
        }
    }

    IEnumerator WaitingCoroutine() {

        yield return new WaitForSeconds(1);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.transform.position = objectDeactivator.transform.position;
    }

    public void KillMe() {

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<ParticleSystem>().Stop();

        foreach (Transform child in transform) {

            if (child.GetComponent<ParticleSystem>()) {

                child.GetComponent<ParticleSystem>().Play();

                StartCoroutine(WaitingCoroutine());
            }
            else {

                child.gameObject.SetActive(false);
            }
        }
    }
}
