using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Blimp_Movement player;

    private void OnTriggerEnter2D(Collider2D collision) {

        IKillable enemy = collision.gameObject.GetComponent<IKillable>();

        if(enemy != null && player.canAttack == true) {

            enemy.KillMe();
        }
    }
}
