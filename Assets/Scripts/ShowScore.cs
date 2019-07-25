using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    Score score;
    Text scoreText;

	// Use this for initialization
	void Start () {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score.getScore();
	}
}
