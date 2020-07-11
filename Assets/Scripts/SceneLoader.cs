using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene() {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    public void LoadStartScene() {
        FindObjectOfType<GameSession>().ResetGameScore();
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Debug.Log("Quit Game Called...");
        Application.Quit();
    }
}
