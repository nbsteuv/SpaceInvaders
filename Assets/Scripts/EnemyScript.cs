using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject laserPrefab;
    public float laserVerticalOffset;
    public float maxCoolDown;

    float coolDown = 1f;
    float timer = 10f;

	void Start () {
		
	}
	
	void Update () {
        IncrementTimer();
        FireIfReady();
	}

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Fire()
    {
        Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + laserVerticalOffset, transform.position.z), Quaternion.identity);
    }

    bool CheckCooldown()
    {
        if(timer >= coolDown)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    void FireIfReady()
    {
        if (CheckCooldown())
        {
            Fire();
            timer = 0;
        }
    }

    void IncrementTimer()
    {
        timer += Time.deltaTime;
    }
}
