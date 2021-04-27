using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay"; //Playerpref for first playthrough
    private static readonly string BackgroundPref = "BackgroundPref"; //Playerpref for background sound
    private static readonly string SoundEffectsPref = "SoundEffectsPref"; //Playerpref for sound effects sound

    private int firstPlayInt; 
    public Slider backgroundSlider, soundEffectsSlider; //Sliders för volymen
    private float backgroundFloat, soundEffectsFloat; //Audio

    public AudioSource backgroundAudio; //The audioSource that has the background music
    public AudioSource[] soundEffectsAudio; //Array for the soundEffects audioSources so that all soundeffects get the same volume

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay); //Is this the first playthrough?

        if(firstPlayInt == 0) //If it is the first time playing
        {
            backgroundFloat = 0.25f; //Default volume 
            soundEffectsFloat = 0.75f; //Default volume 
            backgroundSlider.value = backgroundFloat; //Sliders value is same as backgroundFloat
            soundEffectsSlider.value = soundEffectsFloat; //Sliders value is same as soundEffectsFloat
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat); //Saves the value through scenes and play sessions
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat); //Saves the value through scenes and play sessions
            PlayerPrefs.SetInt(FirstPlay, -1); //It's no longer their first time playing
        }
        else //If it's not the first time
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref); //Pulls the value from the Playerpref
            backgroundSlider.value = backgroundFloat; //Sets the slider to the value we pulled/saved

            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref); //Pulls the value from the Playerpref
            soundEffectsSlider.value = soundEffectsFloat; //Sets the slider to the value we pulled/saved
        }
    }

    public void SaveSoundSettings() //Saves the sound settings so when we exit the game or scene the values stay consistent throughout the whole game
    {
        Debug.Log("save");
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value); //Saves the value through scenes and play sessions using the sliders value
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value); //Saves the value through scenes and play sessions using the sliders value
    }

    private void OnApplicationFocus(bool inFocus) //When you minimise/pause the game we loose focus of the application. So when a player exits the game we still want to save the values
    {
        if(!inFocus)
        { 
            SaveSoundSettings();
        }
    }

    public void UpdateSound() //Updates the sound
    {
        backgroundAudio.volume = backgroundSlider.value; //The volume of the AudioSource for the background is set to that of the value from the slider

        for(int i = 0; i < soundEffectsAudio.Length; i++) //For every soundeffect in the array...
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value; //...set the volume if the AudioSource to that of the value from the slider
        }
    }
   
}
