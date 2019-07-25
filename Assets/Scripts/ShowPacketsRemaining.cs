using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPacketsRemaining : MonoBehaviour {

    RemainingPackets remainingPackets;
    Text remainingPacketsText;
	// Use this for initialization
	void Start () {
        remainingPackets = GameObject.FindGameObjectWithTag("GameController").GetComponent<RemainingPackets>();
        remainingPacketsText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        remainingPacketsText.text = "Packets Remaining: " + remainingPackets.getPackets();
	}
}
