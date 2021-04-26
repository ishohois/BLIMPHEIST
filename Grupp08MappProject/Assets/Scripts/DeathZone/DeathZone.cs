using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameOver gameOverScreen;
    //Destroy() Method
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    collision.gameObject.Destroy();
    //}

    //Health Depletion Method
    //public int maxHealth = 3;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") == true)
    //    {
    //        collision.gameObject.GetComponent<HealthSystem>().DamageEntity(3);
    //    }
    //}

    //SetActive Method
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.gameObject.SetActive(false);
            //Animation goes here
            Debug.Log("Player has died.");
            gameOverScreen.ShowGameOverScreen();
        }
    }
}
