using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    void Start() {
        Brick.OnDestroyed += Brick_OnDestroyed;
        LoseCollider.OnBallLeftArea += LoseCollider_OnBallLeftArea; 
    }

    void OnDestroy() {
        Brick.OnDestroyed -= Brick_OnDestroyed;
        LoseCollider.OnBallLeftArea -= LoseCollider_OnBallLeftArea;
    }

    void Brick_OnDestroyed() {
        if (Brick.breakableCount <= 0)
            NextLevel();
    }

    void LoseCollider_OnBallLeftArea() {
        GameOver();
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void NewGame() {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(1);
    }

    public void NextLevel() {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void GameOver() {
        int gameOverIndex = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(gameOverIndex);
    }

    public void Quit() {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}
