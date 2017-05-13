using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationScript : MonoBehaviour {

    public float speed;
    public float maxOffset;

    List<RowScript> rowScripts;
    float startX;
    float goalX;
    float startTime;

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
        MoveGoalX();
        if (CheckRowsReadytoMove())
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
            rowScript.SetSpeed(speed);
            rowScript.SetGoalPosition(newXPosition);
        }
    }

    void MoveGoalX()
    {
        if(goalX == maxOffset)
        {
            maxOffset = -maxOffset;
            startX = goalX;
            startTime = Time.time;
        }

        float timeDifference = Time.time - startTime;
        float distanceTraveled = speed * timeDifference;

        float totalDistance = Mathf.Abs(startX - maxOffset);
        float fracJourney = distanceTraveled / totalDistance;
        goalX = Mathf.Lerp(startX, maxOffset, fracJourney);
    }

}
