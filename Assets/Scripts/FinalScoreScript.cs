using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour {

    public Text scoreDisplay;

    int scoreValue;
    int scoreCurrent;

	void Update () {
        MoveScore();
	}

    public void SetScore(int score)
    {
        scoreValue = score;
    }

    void MoveScore()
    {
        scoreCurrent = scoreValue;
        scoreDisplay.text = scoreCurrent.ToString();
    }
}
