using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            LoadNextLevel();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void LoadNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}
