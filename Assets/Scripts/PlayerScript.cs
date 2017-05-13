using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    float cameraToBackgroundDistance = 10f;
    float rightBoundary;
    float leftBoundary;

	void Start () {
        rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraToBackgroundDistance)).x;
        leftBoundary = -rightBoundary;
    }
	
	void Update () {
        float mousePositionX = Input.mousePosition.x / Screen.width;
        float newPositionX = Camera.main.ViewportToWorldPoint(new Vector3(mousePositionX, 0, cameraToBackgroundDistance)).x;
        newPositionX = Mathf.Clamp(newPositionX, leftBoundary, rightBoundary);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

    }
}
