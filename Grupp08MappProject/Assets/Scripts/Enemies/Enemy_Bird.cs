using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird : MonoBehaviour, IKillable
{
    [SerializeField] private float timer = 1f;
    public ObjectDeactivator objectDeactivator;
    public ParticleSystem smoke;
    public ParticleSystem death;

    private void Start() {

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
        smoke.gameObject.SetActive(false);
        death.gameObject.SetActive(false);
    }

    public void KillMe() {

        //D�d Ljudeffekter + Partikeleffekter
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        smoke.Stop();
        death.Play();

        foreach (Transform child in transform) {

            if (child.GetComponent<ParticleSystem>()) {

            }
            else {

                child.gameObject.SetActive(false);
            }
        }

        StartCoroutine(WaitingCoroutine());
    }
}
