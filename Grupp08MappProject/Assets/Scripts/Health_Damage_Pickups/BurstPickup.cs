using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstPickup : Pickup
{
    [SerializeField] private int burstsPerTake = 1;
    public AudioSource audio;

    private void Start() {

        audio = GameObject.Find("Audio Source- Burst PickUp Sound").GetComponent<AudioSource>();
    }

    public override void GiveEffect(PlayerState player)
    {
        player.AddBurst(burstsPerTake);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {

            audio.Play();
            gameObject.SetActive(false);

        }
    }
}
