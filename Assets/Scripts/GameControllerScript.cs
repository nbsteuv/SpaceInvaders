using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    LevelManagerScript levelManagerScript;

	void Start () {

        GameObject.DontDestroyOnLoad(gameObject);
        
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.L))
        {
            levelManagerScript.LoadLose();
        }

	}

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        GameObject LevelManager = (GameObject)GameObject.Find("LevelManager");
        levelManagerScript = LevelManager.GetComponent<LevelManagerScript>();
    }
}
