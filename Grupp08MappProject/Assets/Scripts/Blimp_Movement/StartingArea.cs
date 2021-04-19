using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingArea : MonoBehaviour
{
    public Blimp_Movement blimp;


    //private void OnCollisionStay2D(Collision2D collision) {
        
    //    if(collision.gameObject.CompareTag("Player") == true) {

    //        blimp.SetHasLeftAreaToFalse();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {

            blimp.returnedToStartArea = true;
            blimp.SetHasLeftAreaToFalse();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player") == true) {

            blimp.returnedToStartArea = false;
            blimp.SetHasLeftAreaToTrue();
        }
    }

}
