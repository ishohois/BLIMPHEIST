using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird : MonoBehaviour, IKillable
{
    [SerializeField] private float timer = 1f;
    public ObjectDeactivator objectDeactivator;

    private void Start() {

        objectDeactivator = GameObject.FindObjectOfType<ObjectDeactivator>();
    }

    private void OnEnable() {

        foreach (Transform child in transform) {

            child.gameObject.SetActive(true);
        }
    }

    IEnumerator WaitingCoroutine() {

        yield return new WaitForSeconds(timer);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.transform.position = objectDeactivator.transform.position;
    }

    public void KillMe() {

        //Död Ljudeffekter + Partikeleffekter
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<ParticleSystem>().Stop();

        foreach (Transform child in transform) {

            if (child.GetComponent<ParticleSystem>()) {

                //Transform collisionObject =  GameObject.FindObjectOfType<DeathZone>().transform;
                //child.GetComponent<ParticleSystem>().collision.SetPlane(1, collisionObject);
                child.GetComponent<ParticleSystem>().Play();
            }
            else {

                child.gameObject.SetActive(false);
            }
        }

        StartCoroutine(WaitingCoroutine());
    }
}
