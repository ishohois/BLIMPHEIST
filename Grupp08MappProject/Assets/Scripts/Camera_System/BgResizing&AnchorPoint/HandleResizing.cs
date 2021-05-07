using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleResizing : MonoBehaviour
{
    private Camera main;

    public SpriteRenderer sr;
    //public Collider2D collider;


    //public bool usingSRBounds;

    private void Awake()
    {
        main = Camera.main;
    }

    void Start()
    {

        ResizingBackground();
    }

    private void ResizingBackground()
    {
        var width = sr.bounds.size.x;
        var height = sr.bounds.size.y;

        //var widthCollider = collider.bounds.size.x;
        //var heightCollider = collider.bounds.size.y;

        var worldScreenHeight = main.orthographicSize * 2f;

        var worldScreenWidth = worldScreenHeight * main.aspect;

        //transform.localScale = usingSRBounds ?  
        //    new Vector3(worldScreenWidth / width, worldScreenHeight / height, transform.localScale.z) : 
        //    new Vector3(worldScreenWidth / widthCollider, worldScreenHeight / heightCollider, transform.localScale.z);

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, transform.localScale.z);
    }
}
