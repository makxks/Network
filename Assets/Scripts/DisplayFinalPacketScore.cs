using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalPacketScore : MonoBehaviour {
    
    private Score finalScore;

	// Use this for initialization
	void Start () {
        finalScore = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
	}
	
	// Update is called once per frame
	public void showPacketScore()
    {
        GetComponent<Text>().text = "" + finalScore.getScore();
    }
}
