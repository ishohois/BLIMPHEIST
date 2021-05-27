using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrollHandler : MonoBehaviour
{

    public BG_Scroller_Control[] bg_controls;
    public float[] timeStampsBG;
    public float speedIncrement;

    private bool run = true;
    private float timeCounter;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            timeCounter -= Time.deltaTime;

            if (timeCounter <= 0)
            {
                if (index <= timeStampsBG.Length - 1)
                {
                    timeCounter = timeStampsBG[index];
                    updateBGScrollSpeed();
                    Debug.Log("Updated speed " + index);
                }
                else { run = false; }

                if (index != 0)
                {

                }
                index++;
            }
        }
    }

    private void updateBGScrollSpeed()
    {
        foreach(BG_Scroller_Control bg in bg_controls)
        {
            bg.scrollSpeed += speedIncrement;
        }
    }
}
