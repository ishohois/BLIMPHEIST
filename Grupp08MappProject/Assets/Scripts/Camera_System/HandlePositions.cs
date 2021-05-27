using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePositions : MonoBehaviour
{
    private Camera main;

    public GameObject verticalLimiter;
    public GameObject deathZone;
    public GameObject playerAnchorPoint;
    public float offsetVertical;
    public float offsetDeathZone;
    public float offsetPlayerAnchorPoint;
    public GameObject[] backgroundLayers;
    public bool doRescaleBackground;

    //public SpriteRenderer sr;
    //public Collider2D collider;
    //public bool usingSRBounds;

    public float xMinPos;
    public float yMinPos;

    private void Awake()
    {
        main = Camera.main;
        RelocateColliders();

        if (doRescaleBackground)
        {
            RescaleBackground();
        }
    }

    //private void ResizingBackground()
    //{
    //    var width = sr.bounds.size.x;
    //    var height = sr.bounds.size.y;

    //    //var widthCollider = collider.bounds.size.x;
    //    //var heightCollider = collider.bounds.size.y;

    //    var worldScreenHeight = main.orthographicSize * 2f;

    //    var worldScreenWidth = worldScreenHeight * main.aspect;

    //    //transform.localScale = usingSRBounds ?  
    //    //    new Vector3(worldScreenWidth / width, worldScreenHeight / height, transform.localScale.z) : 
    //    //    new Vector3(worldScreenWidth / widthCollider, worldScreenHeight / heightCollider, transform.localScale.z);

    //    transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, transform.localScale.z);
    //}

    private void RelocateColliders()
    {
        xMinPos = main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        yMinPos = main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        verticalLimiter.transform.position = new Vector3(0f, -(yMinPos) + offsetVertical, transform.position.z);
        deathZone.transform.position = new Vector3(0f, yMinPos - offsetDeathZone, transform.position.z);

        playerAnchorPoint.transform.position = new Vector3(xMinPos + offsetPlayerAnchorPoint, 0, transform.position.z);
    }


    private void RescaleBackground()
    {
        float xMaxViewPort = main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x * 2f;
        float yMaxViewPort = main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y * 2f;

        foreach (GameObject obj in backgroundLayers)
        {
            obj.transform.localScale = new Vector3(xMaxViewPort, obj.transform.localScale.y, obj.transform.localScale.z);
        }
    }
}
