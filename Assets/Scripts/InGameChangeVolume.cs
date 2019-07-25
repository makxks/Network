using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameChangeVolume : MonoBehaviour {

    Slider thisSlider;
    Sounds sounds;

    void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>();
        thisSlider = GetComponent<Slider>();
        thisSlider.value = sounds.getVolume();
    }

    public void changeVolume(float sliderValue)
    {
        AudioSource[] musicAndSounds = GameObject.FindGameObjectWithTag("Sounds").GetComponentsInChildren<AudioSource>();
        for (int i = 0; i < musicAndSounds.Length; i++)
        {
            musicAndSounds[i].volume = sliderValue;
        }
        GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>().setVolume(sliderValue);
    }
}
