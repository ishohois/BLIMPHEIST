using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerState : MonoBehaviour, IDamageable<int>
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private bool weightPickedUp = false;
    [SerializeField] private float gracePeriod = 1f;
    [SerializeField] private float pingPongMultplier = 1f;
    [SerializeField] private int noBurst = 1;

    private Material material;
    private float pingPongValue = 1f;
    private Color color;
    private float alphaValue;
    private bool hurt;
    private float counterGracePeriod;
    private PlayerPickupSystem pps;
    private int initialNoBurst;
    private int maxNoBurst = 3;

    public HealthSystem hs;
    public SpriteRenderer sr;

    void Start()
    {
        hs = new HealthSystem(maxHealth);
        material = sr.material;
        color = material.color;
        alphaValue = material.color.a;
        counterGracePeriod = gracePeriod;
        initialNoBurst = noBurst;
    }

    // Update is called once per frame
    void Update()
    {
        if (hurt)
        {
            counterGracePeriod -= Time.deltaTime;
            color.a = Mathf.Clamp(Mathf.PingPong(Time.time * pingPongMultplier, pingPongValue), 0, pingPongValue);

            if (counterGracePeriod <= 0)
            {
                counterGracePeriod = gracePeriod;
                color.a = alphaValue;
                hurt = false;
            }
            material.color = color;
        }
   
    }

    public void AddBurst(int noBurst)
    {
        if(this.noBurst + noBurst >= maxNoBurst)
        {
            this.noBurst = maxNoBurst;
        }
        else
        {
            this.noBurst += noBurst;
        }
    }


    public void Damage(int damagePoints)
    {
        if (!hurt)
        {
            hs.DamageEntity(damagePoints);
            hurt = true;
        }
    }

    public void Heal(int healPoints)
    {
        hs.HealEntity(healPoints);
    }

    public void Die()
    {
        Debug.Log("Player is dead");
    }
}
