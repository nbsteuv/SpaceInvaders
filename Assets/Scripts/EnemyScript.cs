using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public int pointValue = 1;

    public GameObject laserPrefab;
    public float laserVerticalOffset;
    public float maxCoolDown = 10;

    float coolDown = 1f;
    float timer = 0f;

	void Start () {
        GameObject gameController = GameObject.Find("GameController");
        if (gameController != null)
        {
            GameControllerScript gameControllerScript = gameController.GetComponent<GameControllerScript>();
            gameControllerScript.RegisterEnemyScript(this);
        }
        RandomizeCooldown();
    }
	
	void Update () {
        IncrementTimer();
        FireIfReady();
	}

    public void Die()
    {
        OnDeath();
        Destroy(gameObject);
    }

    public delegate void DeathAction(object source, EventArgs args);
    public event DeathAction Death;

    void OnDeath()
    {
        if(Death != null)
        {
            Death(this, EventArgs.Empty);
        }
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
            RandomizeCooldown();
        }
    }

    void IncrementTimer()
    {
        timer += Time.deltaTime;
    }

    void RandomizeCooldown()
    {
        float randomValue = UnityEngine.Random.Range(0f, maxCoolDown);
        coolDown = randomValue;
    }
}
