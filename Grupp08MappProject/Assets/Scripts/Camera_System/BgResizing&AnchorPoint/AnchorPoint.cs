using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorPoint : MonoBehaviour
{
    public GameObject startPoint;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startPos.x = startPoint.transform.position.x;
        startPos.y = startPoint.transform.position.y;
        transform.position = startPos;
    }
}
