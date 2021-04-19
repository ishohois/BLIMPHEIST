using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingArea2 : MonoBehaviour
{
    public Blimp_Movement blimp;


    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {

            blimp.SetHasLeftAreaToFalse();
            blimp.returnedToStartArea = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {

            blimp.SetHasLeftAreaToTrue();
            blimp.returnedToStartArea = false;
        }
    }
}
