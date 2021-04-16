using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour, Damageable
{
    [SerializeField] private int maxHealth = 3;

    private HealthSystem hs;

    public void Damage(int damagePoints)
    {
        hs.DamageEntity(damagePoints);
    }

    void Start()
    {
        hs = new HealthSystem(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
