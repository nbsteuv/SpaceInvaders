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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Enemy")
        {
            collision.collider.gameObject.GetComponent<EnemyScript>().Die();
            Destroy(gameObject);
        }

        if(collision.collider.gameObject.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerScript>().Die();
            Destroy(gameObject);
        }
    }
}
