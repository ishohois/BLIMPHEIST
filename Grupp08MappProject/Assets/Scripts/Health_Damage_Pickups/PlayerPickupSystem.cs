using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupSystem : MonoBehaviour
{
    public PlayerState playerState;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPickable pickable;
        if ((pickable = collision.gameObject.GetComponent<IPickable>()) != null)
        {

        }
    }
}
