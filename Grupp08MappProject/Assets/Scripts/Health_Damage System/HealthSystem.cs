using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthSystem
{
    public event EventHandler HealthChangedHandler; 

    private int healthPoints;
    private readonly int initialHealthPoints;


    protected virtual void OnHealthChanged(EventArgs e)
    {
        if (HealthChangedHandler != null)
            HealthChangedHandler(this, e);
    }

    public HealthSystem(int healthPoints)
    {
        this.healthPoints = healthPoints;
        initialHealthPoints = healthPoints;
    }

    public void DamageEntity(int damage)
    {
        if (healthPoints - damage > 0)
        {
            healthPoints -= damage;
        }
        OnHealthChanged(EventArgs.Empty);
    }

    public void HealEntity(int hp)
    {
        if(!(healthPoints + hp > initialHealthPoints))
        {
            healthPoints += hp;
        }
        OnHealthChanged(EventArgs.Empty);
    }
}
