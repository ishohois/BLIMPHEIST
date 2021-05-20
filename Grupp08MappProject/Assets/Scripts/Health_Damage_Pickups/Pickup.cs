using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IPickable
{

    [SerializeField] private float deactivationTime = 1f;

    public abstract void GiveEffect(PlayerState player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // logic for deactivating particle effects yada yada
        gameObject.SetActive(false);
    }

}
