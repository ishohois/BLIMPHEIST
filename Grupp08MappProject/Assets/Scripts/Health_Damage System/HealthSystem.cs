using System;
using UnityEngine;

[System.Serializable]
public class HealthSystem
{

    [SerializeField]
    private int healthPoints;
    private readonly int initialHealthPoints;

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
    }

    public void HealEntity(int hp)
    {
        if(!(healthPoints + hp <= initialHealthPoints))
        {
            healthPoints += hp;
        }
    }

    public int getHealthPoints()
    {
        return healthPoints;
    }
}
