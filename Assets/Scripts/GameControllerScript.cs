using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class GameControllerScript : MonoBehaviour {

    public GameObject playerPrefab;
    public bool hideMouse;
    public int lives = 3;

    LevelManagerScript levelManagerScript;
    List<PlayerScript> playerScripts;

	void Start () {

        playerScripts = new List<PlayerScript>();
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
        foreach(PlayerScript playerScript in playerScripts)
        {
            playerScript.Death -= OnPlayerDeath;
        }
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        GameObject LevelManager = (GameObject)GameObject.Find("LevelManager");
        levelManagerScript = LevelManager.GetComponent<LevelManagerScript>();

        if (hideMouse)
        {
            if(scene.name != "Menu" && scene.name != "Win" && scene.name != "Lose")
            {
                Cursor.visible = false;
            } else
            {
                Cursor.visible = true;
            }
        }
    }

    public void RegisterPlayerScript(PlayerScript playerScript)
    {
        playerScripts.Add(playerScript);
        playerScript.Death += OnPlayerDeath;
    }

    void OnPlayerDeath()
    {
        lives--;
        if(lives > 0)
        {
            RespawnPlayer();
        } else
        {
            levelManagerScript.LoadLose();
        }
    }

    void RespawnPlayer()
    {
        GameObject respawnPoint = GameObject.Find("PlayerRespawnPoint");

        if(respawnPoint == null)
        {
            Debug.Log("No player respawn point found.");
            return;
        }

        Vector3 respawnPosition = respawnPoint.transform.position;
 
        Instantiate(playerPrefab, respawnPosition, Quaternion.identity);
    }
}
