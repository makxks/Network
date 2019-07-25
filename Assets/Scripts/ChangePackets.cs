using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePackets : MonoBehaviour {

    GameSettings gameSettings;
	// Use this for initialization
	void Start () {
        gameSettings = GameObject.FindGameObjectWithTag("GameSettings").GetComponent<GameSettings>();
        GetComponent<Slider>().value = gameSettings.getPackets();
	}
	
	public void onSliderChange(float sliderValue)
    {
        gameSettings.setPackets(sliderValue);
    }
}
