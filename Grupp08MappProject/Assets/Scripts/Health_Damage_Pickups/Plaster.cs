using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaster : MonoBehaviour, IPickable
{

    [SerializeField] private int amountHealth = 1;

    public int GetAmountHealth()
    {
        return amountHealth;
    }


    // logic for what happens to the pickup in the pickup script
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
