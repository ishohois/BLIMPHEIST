using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaster : Pickup
{

    [SerializeField] private int amountHealth = 1;

    public int GetAmountHealth()
    {
        return amountHealth;
    }

    public override void GiveEffect(PlayerState player)
    {
        player.Heal(amountHealth);
    }
}
