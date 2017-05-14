using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject laserPrefab;
    public float laserVerticalOffset;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
	}

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Fire()
    {
        Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + laserVerticalOffset, transform.position.z), Quaternion.identity);
    }
}
