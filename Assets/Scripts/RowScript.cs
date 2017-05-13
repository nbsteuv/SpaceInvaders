using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowScript : MonoBehaviour {

    public GameObject enemyPrefab;

    float speed;
    float movementStartTime;
    float startX;
    float goalX;
    bool moving = false;

	void Start () {
        InstantiateEnemies();
        startX = transform.position.x;
        //goalX = startX;
    }
	
	void Update () {
        if (CheckMoveable())
        {
            Shift();
        } else
        {
            moving = false;
        }
	}

    void InstantiateEnemies()
    {
        foreach(Transform child in transform)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child;
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void SetGoalPosition(float newXPosition)
    {
        //Debug.Log("Setting position: " + newXPosition);
        startX = transform.position.x;
        goalX = newXPosition;
    }

    bool CheckMoveable()
    {
        //Debug.Log(goalX + " vs. " + startX);
        if(goalX == startX)
        {
            return false;
        }
        //Debug.Log("Returning as moveable");
        return true;
    }

    void Shift()
    {
        if(moving == false)
        {
            moving = true;
            movementStartTime = Time.time;
        }
        float timeDifference = Time.time - movementStartTime;
        float distanceTraveled = timeDifference * speed;

        Vector3 startPosition = new Vector3(startX, transform.position.y, transform.position.z);
        Vector3 goalPosition = new Vector3(goalX, transform.position.y, transform.position.z);
        float totalDistance = Vector3.Distance(startPosition, goalPosition);

        float fracJourney = distanceTraveled / totalDistance;

        //Debug.Log(fracJourney);

        transform.position = Vector3.Lerp(startPosition, goalPosition, fracJourney);
    }
    
}
