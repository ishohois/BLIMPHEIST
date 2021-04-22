using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstPickup : Pickup
{
    [SerializeField] private int burstsPerTake = 1;

    public override void GiveEffect(PlayerState player)
    {
        player.AddBurst(burstsPerTake);
    }
}
