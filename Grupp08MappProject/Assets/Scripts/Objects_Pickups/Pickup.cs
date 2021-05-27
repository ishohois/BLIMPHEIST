using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IPickable
{

    [SerializeField] protected float deactivationTime = 1f;

    public abstract void GiveEffect(PlayerState player);

}
