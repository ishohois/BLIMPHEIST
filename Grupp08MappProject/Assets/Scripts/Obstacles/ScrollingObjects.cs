using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {

        rd2d = GetComponent<Rigidbody2D>();
        rd2d.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameController.instance.gameOver == true)
        {
            rd2d.velocity = Vector2.zero;
        }
    }
}
