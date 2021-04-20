using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupSystem : MonoBehaviour
{

    public PlayerState player;

    private Plaster plaster = null;
    private Weight weight = null;
    //private Burst burst = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.GetComponent<IPickable>()) != null)
        {
            if ((plaster = collision.gameObject.GetComponent<Plaster>()) != null)
            {
                player.Heal(plaster.GetAmountHealth());
                plaster = null;
            }

            if ((weight = collision.gameObject.GetComponent<Weight>()) != null)
            {
                // add weight to player method or logic
                weight = null;
            }

            //if ((burst = collision.gameObject.GetComponent<Burst>()) != null)
            //{
            //    player.AddBurst(burst.GetNoBurst()) // something like this
            //    plaster = null;
            //}
        }
    }
}
