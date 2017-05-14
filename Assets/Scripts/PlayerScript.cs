using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public GameObject laserPrefab;
    public float laserVerticalOffset;

    float cameraToBackgroundDistance = 10f;
    float playerHalfWidth;
    float rightBoundary;
    float leftBoundary;

	void Start () {
        GameObject.Find("GameController").GetComponent<GameControllerScript>().RegisterPlayerScript(this);

        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, cameraToBackgroundDistance)).x - playerHalfWidth;
        leftBoundary = -rightBoundary;
    }
	
	void Update () {
        float mousePositionX = Input.mousePosition.x / Screen.width;
        float newPositionX = Camera.main.ViewportToWorldPoint(new Vector3(mousePositionX, 0, cameraToBackgroundDistance)).x;
        newPositionX = Mathf.Clamp(newPositionX, leftBoundary, rightBoundary);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + laserVerticalOffset, transform.position.z), Quaternion.identity);
    }

    public void Die()
    {
        OnDeath();
        Destroy(gameObject);
    }

    public delegate void DeathAction();
    public event DeathAction Death;

    public void OnDeath()
    {
        if(Death != null)
        {
            Death();
        }
    }
}
