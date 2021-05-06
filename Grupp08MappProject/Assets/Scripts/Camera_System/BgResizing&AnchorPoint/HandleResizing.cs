using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleResizing : MonoBehaviour
{
    private Camera main;

    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;

        ResizingBackground();
    }

    private void ResizingBackground()
    {
        var width = sr.bounds.size.x;
        var height = sr.bounds.size.y;

        var worldScreenHeight = main.orthographicSize * 2f;

        var worldScreenWidth = worldScreenHeight * main.aspect;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, transform.localScale.z);
    }
}
