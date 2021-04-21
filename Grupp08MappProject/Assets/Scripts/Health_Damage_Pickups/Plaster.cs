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

    public void giveEffect(PlayerState player)
    {
        player.Heal(amountHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // logic for deactivating particle effects yada yada
        gameObject.SetActive(false);
    }

}
