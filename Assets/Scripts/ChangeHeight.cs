using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHeight : MonoBehaviour {

    GameSettings gameSettings;
    // Use this for initialization
    void Start()
    {
        gameSettings = GameObject.FindGameObjectWithTag("GameSettings").GetComponent<GameSettings>();
        GetComponent<Slider>().value = gameSettings.getHeight();
    }

    public void onSliderChange(float sliderValue)
    {
        gameSettings.setHeight(sliderValue);
    }
}
