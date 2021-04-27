using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValueScript : MonoBehaviour
{
    private Text percentageText;
    [SerializeField] Slider slider;

    private void Start()
    {
        percentageText = GetComponent<Text>();
        //percentageText.text = Mathf.RoundToInt(int.Parse(percentageText.text) * 100) + "%";
    }

    public void textUpdate(float value)
    {
        if(value!=null && percentageText != null)
        {
            percentageText.text = Mathf.RoundToInt(value * 100) + "%";
        }
        else
        {
            Debug.Log(value + "  null");

        }
    }

    public void OpenMenu()
    {
        Debug.Log(slider.value);
        textUpdate(slider.value);

    }
}
