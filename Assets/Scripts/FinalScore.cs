using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour {

    private float finalScore;
    private Score score;
    [SerializeField]
    private TimeDisplay time;
    [SerializeField]
    private RemainingPackets packets;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    public void calculateFinalScore()
    {
        finalScore = time.getTimeMultiplier(packets.getTotalPackets()) * score.getScore();


        int scoreValue = (int)finalScore;
        string scoreText = "" + finalScore; // A string representing the score to be shown on the website.
        //int tableID = 0; // Set it to 0 for main highscore table.
        //string extraData = ""; // This will not be shown on the website. You can store any information.
        /*GameJolt.API.Scores.Add(scoreValue, scoreText, tableID, extraData, (bool success) => {
            Debug.Log(string.Format("Score Add {0}.", success ? "Successful" : "Failed"));
        });*/
    }

    public float getFinalScore()
    {
        return finalScore;
    }

}
