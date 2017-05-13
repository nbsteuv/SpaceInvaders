using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationScript : MonoBehaviour {

    public float speed;
    public float maxOffset;

    List<RowScript> rowScripts;

	void Start () {
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
        foreach(RowScript rowScript in rowScripts)
        {
            rowScript.SetSpeed(1);
            rowScript.SetGoalPosition(10f);
        }
	}
}
