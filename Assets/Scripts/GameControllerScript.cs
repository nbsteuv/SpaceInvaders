using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class GameControllerScript : MonoBehaviour {

    public static GameObject instance;

    public GameObject playerPrefab;
    public bool hideMouse;
    public int lives = 3;
    public float respawnDelay = 1;

    float cameraToBackgroundDistance = 10f;

    LevelManagerScript levelManagerScript;
    List<PlayerScript> playerScripts;
    List<FormationScript> formationScripts;
    List<EnemyScript> enemyScripts;

    private void Awake()
    {
        playerScripts = new List<PlayerScript>();
        formationScripts = new List<FormationScript>();
        enemyScripts = new List<EnemyScript>();

        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = gameObject;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Start () {
        
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

        foreach(FormationScript formationScript in formationScripts)
        {
            formationScript.FormationDestroyed -= OnFormationDestroyed;
        }

        foreach(EnemyScript enemyScript in enemyScripts)
        {
            enemyScript.Death -= OnEnemyDeath;
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

    public void RegisterFormationScript(FormationScript formationScript)
    {
        formationScripts.Add(formationScript);
        formationScript.FormationDestroyed += OnFormationDestroyed;
    }

    public void RegisterEnemyScript(EnemyScript enemyScript)
    {
        enemyScripts.Add(enemyScript);
        enemyScript.Death += OnEnemyDeath;
    }

    void OnPlayerDeath()
    {
        lives--;
        if(lives > 0)
        {
            Invoke("RespawnPlayer", respawnDelay);
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

        float mousePositionX = Input.mousePosition.x / Screen.width;
        float newPositionX = Camera.main.ViewportToWorldPoint(new Vector3(mousePositionX, 0, cameraToBackgroundDistance)).x;

        Vector3 respawnPosition = new Vector3(newPositionX, respawnPoint.transform.position.y, respawnPoint.transform.position.z);
  
        Instantiate(playerPrefab, respawnPosition, Quaternion.identity);
    }

    void OnFormationDestroyed()
    {
        levelManagerScript.LoadNextLevel();
    }

    void OnEnemyDeath(object source, EventArgs args)
    {
        EnemyScript enemyScript = (EnemyScript)source;
        int pointValue = GetPointValueFromEnemyScript(enemyScript);
        AddPoints(pointValue);
    }

    int GetPointValueFromEnemyScript(EnemyScript enemyScript)
    {
        int pointValue = enemyScript.pointValue;
        return pointValue;
    }

    void AddPoints(int points)
    {
        Debug.Log(points);
    }

}
