using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private int damageDealer = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamageable<int> player = collision.gameObject.GetComponent<IDamageable<int>>();
        Blimp_Movement blimp = collision.gameObject.GetComponent<Blimp_Movement>();

        if (player != null && blimp.canAttack == true) {

            IKillable enemy = gameObject.GetComponent<IKillable>();
            enemy.KillMe();
        }
        else if (player != null)
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
