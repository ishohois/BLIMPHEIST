using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour, IDamageable<int>
{
    [SerializeField] private int maxHealth = 3;

    private Material material;
    private float pingPongValue = 1f;
    private Color color;

    public HealthSystem hs;
    public SpriteRenderer sr;

    public void Damage(int damagePoints)
    {
        hs.DamageEntity(damagePoints);
    }

    void Start()
    {
        hs = new HealthSystem(maxHealth);
        material = sr.material;
        color = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        color.a = Mathf.Clamp(Mathf.PingPong(Time.time * 4, pingPongValue), 0, pingPongValue);

        material.color = color;

    }
}
