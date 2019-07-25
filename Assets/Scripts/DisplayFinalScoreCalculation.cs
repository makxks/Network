using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScoreCalculation : MonoBehaviour {

    private Score finalScore;
    [SerializeField]
    private TimeDisplay time;
    [SerializeField]
    private RemainingPackets totalPackets;

    // Use this for initialization
    void Start()
    {
        finalScore = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

    public void showCalculation()
    {
        GetComponent<Text>().text = "" + finalScore.getScore() + "  x  " + time.getTimeMultiplier(totalPackets.getTotalPackets());
    }
}
