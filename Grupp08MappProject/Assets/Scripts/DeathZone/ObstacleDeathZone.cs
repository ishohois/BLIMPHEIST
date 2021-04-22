using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeathZone : MonoBehaviour
{
    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.collider.gameObject);
        //Destroy(gameObject);

        //collision.gameObject.SetActive(false);

        //Destroy(collision.gameObject);

        if (collision.CompareTag("Enemy") == true)  //collision.gameObject.tag == "Enemy"
        { //does the object collided with have the tag in question?
            //Destroy(collision.gameObject); //if so, destroy that object!

        }
    }
    */

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Enemy die");
        }
    }
}
