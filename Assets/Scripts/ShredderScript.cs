using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject LevelManager = (GameObject)GameObject.Find("LevelManager");
            LevelManagerScript levelManagerScript = LevelManager.GetComponent<LevelManagerScript>();
            levelManagerScript.LoadLose();
        }
        Destroy(collision.gameObject);
    }
}
