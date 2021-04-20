using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupSystem : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPickable pickable;
        
        if ((pickable = collision.gameObject.GetComponent<IPickable>()) != null)
        {
            Pickup(pickable);
        }
    }

    public void Pickup(IPickable pickable)
    {
        
    }

}
