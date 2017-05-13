using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationScript : MonoBehaviour {

    public float speedX;
    public float speedY;
    public float yIncrement;
    public float maxOffset;

    List<RowScript> rowScripts;
    float startX;
    float goalX;
    float startTime;
    float startY;
    float goalY;
    bool movingY;

	void Start () {
        startX = transform.position.x;
        startTime = Time.time;

        rowScripts = new List<RowScript>();
		foreach(Transform child in transform)
        {
            //Get and register row script
            GameObject row = child.gameObject;
            RowScript rowScript = row.GetComponent<RowScript>();
            rowScripts.Add(rowScript);
        }
	}
	
	void Update () {
        MoveXGoal();

        if (!movingY && CheckRowsReadytoMove())
        {
            SetNewRowGoals(goalX);
        }

    }

    bool CheckRowsReadytoMove()
    {
        bool rowReady = true;
        foreach (RowScript rowScript in rowScripts)
        {
            float rowGoalX = rowScript.GetGoalPosition();
            float rowCurrentx = rowScript.GetCurrentPosition();
            if(rowCurrentx != rowGoalX)
            {
                rowReady = false;
            }
        }
        return rowReady;
    }

    void SetNewRowGoals(float newXPosition)
    {
        foreach(RowScript rowScript in rowScripts)
        {
            //Pass speed to rows so it can be increased over time in one place
            rowScript.SetSpeed(speedX);
            rowScript.SetGoalPosition(newXPosition);
        }
    }

    void MoveXGoal()
    {
        if(goalX == maxOffset)
        {
            SwitchDirections();
            
        } else
        {
            float timeDifference = Time.time - startTime;
            float distanceTraveled = speedX * timeDifference;

            float totalDistance = Mathf.Abs(startX - maxOffset);
            float fracJourney = distanceTraveled / totalDistance;
            goalX = Mathf.Lerp(startX, maxOffset, fracJourney);
        }
    }

    void SwitchDirections()
    {
        maxOffset = -maxOffset;
        startX = goalX;
        startTime = Time.time;
    }

}
