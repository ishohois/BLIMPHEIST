using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroller : MonoBehaviour
{

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeedBG, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero; 
        }
    }
}
