using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    public float scrollSpeed;
    public float scrollSpeedMultiplier;   
    
    private Rigidbody2D rd2d;

    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        rd2d.velocity = Vector2.zero;
    }

    private void OnEnable()
    {
        rd2d.velocity = new Vector2(scrollSpeed * scrollSpeedMultiplier, 0);
    }

}
