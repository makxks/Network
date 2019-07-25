using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private float score;

    public float getScore()
    {
        return score;
    }

    public float increaseScore(float scoreIncrease)
    {
        return score += scoreIncrease;
    }
}
