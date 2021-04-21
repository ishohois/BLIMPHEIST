using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupSystem : MonoBehaviour
{
    public PlayerState player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickable ipickable;
        if ((ipickable = collision.gameObject.GetComponent<IPickable>()) != null)
        {
            ipickable.giveEffect(player);
        }
    }
}
