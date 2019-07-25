using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {

    Sounds sounds;
	// Use this for initialization
	void Start () {
        sounds = GameObject.FindGameObjectWithTag("Sounds").GetComponent<Sounds>();
        GetComponent<Slider>().value = sounds.getVolume();
	}
	
	public void changeVolume(float sliderValue)
    {
        sounds.changeVolume(sliderValue);
    }
}
