using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthSystem
{
    public event EventHandler OnHealthChanged; 

    private int healthPoints;
    private readonly int initialHealthPoints;

    public HealthSystem(int healthPoints)
    {
        this.healthPoints = healthPoints;
        initialHealthPoints = healthPoints;
    }

    public void DamagePlayer(int damage)
    {
        if (healthPoints - damage > 0)
        {
            healthPoints -= damage;
        }
    }

    public void HealPlayer(int hp)
    {
        if(!(healthPoints + hp > initialHealthPoints))
        {
            healthPoints += hp;
        }
    }
}
