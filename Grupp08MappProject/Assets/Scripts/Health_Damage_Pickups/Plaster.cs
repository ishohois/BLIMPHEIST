using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaster : Pickup
{

    [SerializeField] private int amountHealth = 1;
    public AudioSource audio;

    private void Start() {

        //audio = GameObject.Find(Namn PÅ SpelObjektet med AudioSource).GetComponent<AudioSource>();
    }

    public int GetAmountHealth()
    {
        return amountHealth;
    }

    public override void GiveEffect(PlayerState player)
    {
        player.Heal(amountHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            //audio.Play();
            gameObject.SetActive(false);
        }
    }
}
