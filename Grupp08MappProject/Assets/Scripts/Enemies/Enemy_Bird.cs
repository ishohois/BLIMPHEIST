using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird : MonoBehaviour, IKillable
{
    [SerializeField] private float timer = 1f;
    public ObjectDeactivator objectDeactivator;
    public ParticleSystem smoke;
    public ParticleSystem death;
    public AudioSource audio;

    private void Start() {

        audio = GameObject.Find("Audio Source- Bird Death").GetComponent<AudioSource>();
        smoke.Play();
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
        smoke.Stop();
        death.Play();
        audio.Play();

        foreach (Transform child in transform) {

            if (child.GetComponent<ParticleSystem>()) {
                continue;
            }
            else {

                child.gameObject.SetActive(false);
            }
        }

        StartCoroutine(WaitingCoroutine());
    }
}
