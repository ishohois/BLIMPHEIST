using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeactivator : MonoBehaviour
{
    public int objectCounter; 
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        IncrementObjectCounter();
    }

    public void IncrementObjectCounter() {

        objectCounter++;
    }

    public int GetObjectCounter()
    {
        return objectCounter;
    }
}
