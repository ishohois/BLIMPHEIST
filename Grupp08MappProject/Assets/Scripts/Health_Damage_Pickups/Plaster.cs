using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaster : MonoBehaviour, IPickable<int>
{

    [SerializeField] private int amountHealth = 1;

    public void pickup()
    {
        throw new System.NotImplementedException();
    }

}
