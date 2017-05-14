using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    public float speed;

	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed, 0);
	}
	
	void Update () {
		
	}
}
