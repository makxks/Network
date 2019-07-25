using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour {

    private Text timeText;
    private float time;
    private int displayedSeconds;
    private int displayedMinutes;
    private bool gameComplete;

	// Use this for initialization
	void Start () {
        timeText = GetComponent<Text>();
        displayedMinutes = 0;
        displayedSeconds = 0;
        time = 0;
        gameComplete = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameComplete)
        {
            time += Time.deltaTime;
        }
        displayedSeconds = (int)time % 60;
        displayedMinutes = (int)time / 60;
        string leadingZeroSeconds = "0";
        string leadingZeroMinutes = "0";
        if (displayedSeconds > 9)
        {
            leadingZeroSeconds = "";
        }
        if(displayedMinutes > 9)
        {
            leadingZeroMinutes = "";
        }
        timeText.text = "" + leadingZeroMinutes + displayedMinutes + ":" + leadingZeroSeconds + displayedSeconds;
	}

    public float getTimeMultiplier(int totalPackets)
    {
        float multiplier = 1;
        if (time < (60 * totalPackets))
        {
            multiplier = (((60 * totalPackets) - time)/60) + 1;
        }
        return multiplier;
    }

    public void setGameComplete(bool isComplete)
    {
        gameComplete = isComplete;
    }
}
