using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public AudioSource audio;

    private void OnEnable() {

        audio.pitch = UnityEngine.Random.Range(1f, 1.3f);
        audio.Play();
    }
}
