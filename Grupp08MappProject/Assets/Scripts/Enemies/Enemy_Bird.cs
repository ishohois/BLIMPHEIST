using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bird : MonoBehaviour, IKillable
{
    public ObjectDeactivator objectDeactivator;

    private void Start() {

        objectDeactivator = GameObject.FindObjectOfType<ObjectDeactivator>();
    }

    public void KillMe() {

        gameObject.GetComponent<BoxCollider2D>().enabled = false; // PROBLEM

        foreach (Transform child in transform) {

            child.gameObject.SetActive(false);
        }

        // D�d partiklar
        // D�d ljudeffekt
        // Inaktivera grejer efter ovanst�ende har spelat klart

        //objectDeactivator.IncrementObjectCounter();
    }
}
