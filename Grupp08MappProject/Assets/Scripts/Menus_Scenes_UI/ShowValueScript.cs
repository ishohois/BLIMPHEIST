using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowValueScript : MonoBehaviour
{
    private static readonly string BGProcentPref = "BGProcentPref";
    private static readonly string SFXProcentPref = "SFXProcentPref";

    //public Text BGpercentageText;
    //public Text SFXpercentageText;
    public TMP_Text procentText;
    //[SerializeField] Slider slider;
    public Slider backgroundSlider, soundEffectsSlider; //Sliders för volymen

    private void Start()
    {
        //BGpercentageText = GetComponent<Text>();
        //SFXpercentageText = GetComponent<Text>();
        procentText = GetComponent<TMP_Text>();
        backgroundSlider.value = PlayerPrefs.GetFloat("BGProcentPref");
        soundEffectsSlider.value = PlayerPrefs.GetFloat("SFXProcentPref");
        //percentageText.text = Mathf.RoundToInt(int.Parse(percentageText.text) * 100) + "%";
    }

    private void Update()
    {
        PlayerPrefs.SetFloat(BGProcentPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SFXProcentPref, soundEffectsSlider.value);
    }

    public void textUpdate(float value)
    {
        if(value!=null && procentText != null )
        {
            //BGpercentageText.text = Mathf.RoundToInt(value * 100) + "%";
            //SFXpercentageText.text = Mathf.RoundToInt(value * 100) + "%";
            procentText.text = Mathf.RoundToInt(value * 100) + "%";
        }
        else
        {
            Debug.Log(value + "  null");

        }
        //PlayerPrefs.SetFloat("ProcentPref", slider.value);
    }

    public void OpenMenu()
    {
        Debug.Log(soundEffectsSlider.value);
        Debug.Log(backgroundSlider.value);

        textUpdate(soundEffectsSlider.value);
        textUpdate(backgroundSlider.value);

        PlayerPrefs.SetFloat(BGProcentPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SFXProcentPref, soundEffectsSlider.value);
    }

    private void OnApplicationFocus(bool inFocus) //When you minimise/pause the game we loose focus of the application. So when a player exits the game we still want to save the values
    {
        if (!inFocus)
        {
            //OpenMenu();
            PlayerPrefs.SetFloat(BGProcentPref, backgroundSlider.value);
            PlayerPrefs.SetFloat(SFXProcentPref, soundEffectsSlider.value);
        }
    }
}
