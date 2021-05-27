using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroller_Control : MonoBehaviour {

    //ZTest Always
    public float scrollSpeed;
    public Renderer meshRenderer;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0f);
    }
}
