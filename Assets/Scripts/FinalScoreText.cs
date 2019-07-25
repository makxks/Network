using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreText : MonoBehaviour {

    private FinalScore finalScore;

    void Start()
    {
        finalScore = GameObject.FindGameObjectWithTag("Score").GetComponent<FinalScore>();
    }
	
	public void showFinalScore()
    {
        GetComponent<Text>().text = "" + finalScore.getFinalScore();
    }
}
