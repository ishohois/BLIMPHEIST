using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingArea2 : MonoBehaviour
{
    public Blimp_Movement blimp;
    public PlayerState playerState;

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {

            blimp.SetHasLeftAreaToFalse();
            playerState.AddBurst(1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {

            blimp.SetHasLeftAreaToTrue();
        }
    }
}
