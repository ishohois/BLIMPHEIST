using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rise : MonoBehaviour
{
    public Blimp_Movement blimp;
    public Button button;

    public void OnButtonPress() {

        if (Input.GetKey(KeyCode.Mouse0) == true) {

            blimp.flying = true;
        }
        else {

            blimp.flying = false;
        }
    }

    void Update() {
        
        if(Input.touchCount > 0) {

            Touch touch = Input.GetTouch(0);
            
        }
    }
}
