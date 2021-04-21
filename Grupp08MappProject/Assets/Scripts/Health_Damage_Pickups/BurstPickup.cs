using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstPickup : MonoBehaviour, IPickable
{
    [SerializeField] private int burstsPerTake = 1;


    public void GiveEffect(PlayerState player) {

        player.AddBurst(burstsPerTake);
    }

}
