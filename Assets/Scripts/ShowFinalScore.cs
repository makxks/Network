using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFinalScore : MonoBehaviour {

    [SerializeField]
    private RemainingPackets packets;
    [SerializeField]
    private GameObject packetScore;
    [SerializeField]
    private GameObject timeMultiplier;
    [SerializeField]
    private GameObject calculation;
    [SerializeField]
    private GameObject finalScoreDisplay;
    [SerializeField]
    private GameObject finalScore;
    [SerializeField]
    private GameObject buttons;
    private FinalScore score;

    void Start()
    {
        packetScore.SetActive(false);
        timeMultiplier.SetActive(false);
        calculation.SetActive(false);
        finalScoreDisplay.SetActive(false);
        finalScore.SetActive(false);
        buttons.SetActive(false);
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<FinalScore>();
    }

    public IEnumerator showScore()
    {
        packetScore.GetComponentInChildren<DisplayFinalPacketScore>().showPacketScore();
        timeMultiplier.GetComponentInChildren<DisplayFinalTimeMultiplier>().showTimeMultiplier();
        calculation.GetComponentInChildren<DisplayFinalScoreCalculation>().showCalculation();
        finalScore.GetComponentInChildren<FinalScoreText>().showFinalScore();

        finalScoreDisplay.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        packetScore.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        timeMultiplier.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        calculation.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        finalScore.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        buttons.SetActive(true);
    }

}
