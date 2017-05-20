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
    int displayedScore;

    AudioSource incrementSound;

    private void Awake()
    {
        incrementSound = GetComponent<AudioSource>();
    }

    void Update () {
        AccelerateMove();
        MoveScore();
	}

    public void SetScore(int score)
    {
        scoreValue = score;
        scoreDisplay.text = scoreCurrent.ToString();
    }

    void MoveScore()
    {
        if (scoreCurrent < scoreValue)
        {
            scoreCurrent = scoreCurrent + incrementSpeed * Time.deltaTime;
        }
        int newDisplayScore = Mathf.RoundToInt(scoreCurrent);
        if (newDisplayScore != displayedScore)
        {
            displayedScore = newDisplayScore;
            scoreDisplay.text = newDisplayScore.ToString();
            incrementSound.Play();
        }
    }

    void AccelerateMove()
    {
        incrementSpeed = incrementSpeed + incrementAcceleration * Time.deltaTime;
    }
}
