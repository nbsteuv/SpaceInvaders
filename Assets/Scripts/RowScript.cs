using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowScript : MonoBehaviour {

    public GameObject enemyPrefab;

	void Start () {
        InstantiateEnemies();
	}
	
	void Update () {
		
	}

    void InstantiateEnemies()
    {
        foreach(Transform child in transform)
        {
            GameObject enemy = (GameObject)Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
            enemy.transform.parent = child;
        }
    }
}
