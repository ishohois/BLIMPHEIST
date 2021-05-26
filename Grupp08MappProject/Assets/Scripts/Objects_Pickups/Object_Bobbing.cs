using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Bobbing : MonoBehaviour
{

    private float originalY;
    [SerializeField] private float bobSpeed = 4f;
    [SerializeField] private float bobHeight = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        originalY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = Mathf.Sin(Time.time * bobSpeed) * bobHeight + originalY;
        transform.position = new Vector2(transform.position.x, newY);
    }
}
