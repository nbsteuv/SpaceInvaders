using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour {

    public Text scoreDisplay;
    public float incrementSpeed;
    public float incrementAcceleration;

    int scoreValue;
    float scoreCurrent = 0;

	void Update () {
        AccelerateMove();
        MoveScore();
	}

    public void SetScore(int score)
    {
        scoreValue = score;
    }

    void MoveScore()
    {
        Debug.Log("moving score");
        Debug.Log(scoreCurrent);
        Debug.Log(scoreValue);
        if (scoreCurrent < scoreValue)
        {
            Debug.Log("score is less");
            scoreCurrent = scoreCurrent + incrementSpeed * Time.deltaTime;
        }
        scoreDisplay.text = Mathf.RoundToInt(scoreCurrent).ToString();
    }

    void AccelerateMove()
    {
        incrementSpeed = incrementSpeed + incrementAcceleration * Time.deltaTime;
    }
}
