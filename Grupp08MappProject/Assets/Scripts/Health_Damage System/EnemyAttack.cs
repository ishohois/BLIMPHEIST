using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private int damageDealer = 1;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    IDamageable<int> player = collision.gameObject.GetComponent<IDamageable<int>>(); 

    //    if(player != null)
    //    {
    //        player.Damage(damageDealer);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable<int> player = collision.gameObject.GetComponent<IDamageable<int>>();

        if (player != null)
        {
            player.Damage(damageDealer);
        }
    }
}
