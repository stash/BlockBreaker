﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit() {
        Application.Quit();
    }
}
