using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour, IPickable<bool>
{
    public PlayerState playerState;
    [SerializeField] private bool colliding = false;


    // Update is called once per frame
    void Update()
    {
        if(colliding == true) {

            pickup(true);
        }
    }

    public void pickup(bool pickedUp) {

        playerState.SetWeightPickedUpToTrue(pickedUp);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")) {

            colliding = true;
        }
    }

        
}
