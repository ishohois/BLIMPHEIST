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
    [SerializeField] private int startNoBurst = 1;
    [SerializeField] private int startNoWeights = 1;
    [SerializeField] private int noBursts;

    private float pingPongValue = 1f;
    private Color color;
    private float alphaValue = 1f;
    private bool hurt;
    private float counterGracePeriod;
    private int maxNoBurst = 3;

    public Material material;
    public bool startBurstUsed;
    public HealthSystem hs;
    public GameOver gameover;
    [SerializeField] ParticleSystem lowHealthEffect;
    [SerializeField] ParticleSystem hurtEffect;
    [SerializeField] ParticleSystem burstLost;
    public ParticleSystem warning;

    public delegate void UpdateBurst(PlayerState player);
    public static event UpdateBurst updateBurst;

    public AudioSource hitSound; //Sound when you get hit
    public AudioSource healSound; //Det ljud som spelas när man tar upp heal
    public AudioSource gracePeriodSound; //Varningssignal under grace period

    void Start()
    {
        hs = new HealthSystem(maxHealth);
        color = material.color;
        counterGracePeriod = gracePeriod;
        noBursts = startNoBurst;

        if(updateBurst != null)
        {
            updateBurst(this);
        }

        material.SetColor("_Color", new Color(1, 1, 1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        if (hurt && hs.GetHealthPoints() != 0)
        {
            counterGracePeriod -= Time.deltaTime;
            color.a = Mathf.Clamp(Mathf.PingPong(Time.time * pingPongMultplier, pingPongValue), 0, pingPongValue);

            if (counterGracePeriod <= 0)
            {
                counterGracePeriod = gracePeriod;
                color.a = alphaValue;
                hurt = false;
            }
            material.SetColor("_Color", color);
        }

        //Low Health Smoke Effect
        var emission = lowHealthEffect.emission;
        if (hs.GetHealthPoints() == 1 && emission.enabled == false)
        {
            emission.enabled = true;
        }
        else if (hs.GetHealthPoints() > 1 && emission.enabled == true)
        {
            emission.enabled = false;
        }
    }

    public void AddBurst(int noBurst)
    {
        if(noBursts + noBurst >= maxNoBurst)
        {
            noBursts = maxNoBurst;
        }
        else
        {
            noBursts += noBurst;
        }

        if(updateBurst != null)
        {
            updateBurst(this);
        }
    }

    public void UseBurst() {

        noBursts -= 1;
        burstLost.Play();

        if(noBursts < 0) {

            noBursts = 0;
        }
        if(updateBurst != null)
        {
            updateBurst(this);
        }
    }

    public int GetBursts() {

        return noBursts;
    }

    public void Damage(int damagePoints)
    {
        if (!hurt)
        {
            hitSound.pitch = UnityEngine.Random.Range(0.6f, 0.9f);
            hitSound.Play();

            if (hs.GetHealthPoints() > 1) {
                gracePeriodSound.Play();
            }
            hurtEffect.Play();
            hs.DamageEntity(damagePoints);
            hurt = true;
        }
    }

    public void Heal(int healPoints)
    {
        hs.HealEntity(healPoints);

        healSound.pitch = UnityEngine.Random.Range(0.8f,1.0f);
        healSound.Play();
    }

    public void Die()
    {
        material.SetColor("_Color", new Color(1, 1, 1, 0));
        hs.Die();
        gameover.ShowGameOverScreen();
    }

}
