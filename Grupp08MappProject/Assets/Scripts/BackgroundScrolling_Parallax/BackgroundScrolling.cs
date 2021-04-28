using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollingSpeed;
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollingSpeed * Time.deltaTime, 0f);
    }
}
