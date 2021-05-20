using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private int damageDealer = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamageable<int> player = collision.gameObject.GetComponent<IDamageable<int>>();

        if (player != null)
        {
            player.Damage(damageDealer);

            PlayerState playerState;

            if((playerState = collision.gameObject.GetComponent<PlayerState>()) != null && playerState.hs.GetHealthPoints() <= 0)
            {
                playerState.Die();
            }
        }
    }
}
