using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float scrollSpeed;

    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

        rd2d.velocity = new Vector2(scrollSpeed, 0);
    }

    private void OnDisable()
    {
        rd2d.velocity = Vector2.zero;
    }

    private void OnEnable()
    {
        rd2d.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {

        //if (GameController.instance.gameOver == true)
        //{
        //
        //}
    }
}
