using System;
using UnityEngine;

[System.Serializable]
public class HealthSystem
{
    public event EventHandler HealthChangedHandler; 

    [SerializeField]
    private int healthPoints;
    private readonly int initialHealthPoints;


    public virtual void OnHealthChanged(EventArgs e)
    {
        HealthChangedHandler?.Invoke(this, e);
    }

    public HealthSystem(int healthPoints)
    {
        this.healthPoints = healthPoints;
        initialHealthPoints = healthPoints;
    }

    public void DamageEntity(int damage)
    {
        if (healthPoints - damage >= 0)
        {
            healthPoints -= damage;
        }
        OnHealthChanged(EventArgs.Empty);
    }

    public void HealEntity(int hp)
    {
        if(!(healthPoints + hp <= initialHealthPoints))
        {
            healthPoints += hp;
        }
        OnHealthChanged(EventArgs.Empty);
    }

    public int getHealthPoints()
    {
        return healthPoints;
    }
}
