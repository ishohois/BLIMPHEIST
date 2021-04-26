using System;
using UnityEngine;

[System.Serializable]
public class HealthSystem
{

    [SerializeField]
    private int healthPoints;
    private readonly int initialHealthPoints;

    public delegate void UpdateHealth(HealthSystem health);
    public static event UpdateHealth updateHealth;

    public HealthSystem(int healthPoints)
    {
        this.healthPoints = healthPoints;
        initialHealthPoints = healthPoints;
        if(updateHealth != null)
        {
            updateHealth(this);
        }
    }

    public void DamageEntity(int damage)
    {
        if (healthPoints - damage >= 0)
        {
            healthPoints -= damage;
        }
        if (updateHealth != null)
        {
            updateHealth(this);
        }
    }

    public void HealEntity(int hp)
    {
        if(healthPoints + hp >= initialHealthPoints)
        {
            healthPoints = initialHealthPoints;
        }
        else
        {
            healthPoints += hp;
        }
        if (updateHealth != null)
        {
            updateHealth(this);
        }
    }

    public int GetHealthPoints()
    {
        return healthPoints;
    }
}
