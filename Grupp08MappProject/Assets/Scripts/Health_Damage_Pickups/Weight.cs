using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour, IPickable
{
    public PlayerState playerState;
    [SerializeField] private bool colliding = false;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("Player")) {

            colliding = true;
        }
    }

    public void giveEffect(PlayerState player)
    {
        throw new System.NotImplementedException();
    }
}
