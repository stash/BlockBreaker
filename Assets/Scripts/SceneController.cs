using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static event Action OnSceneEnding;
    public static event Action OnDeath;
    public bool hidePointer = true;
    public float sceneEndDelay = 2.5f;

    WaitForSeconds wait;

    void Start() {
        wait = new WaitForSeconds(sceneEndDelay);

        if (hidePointer) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        } else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        Brick.OnDestroyed += Brick_OnDestroyed;
        LoseCollider.OnBallLeftArea += LoseCollider_OnBallLeftArea; 
    }

    void OnDestroy() {
        Brick.OnDestroyed -= Brick_OnDestroyed;
        LoseCollider.OnBallLeftArea -= LoseCollider_OnBallLeftArea;
    }

    void Brick_OnDestroyed() {
        if (Brick.breakableCount <= 0) {
            NextLevel();
        }
    }

    void LoseCollider_OnBallLeftArea() {
        OnDeath();
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
        OnSceneEnding();
        StartCoroutine(DelayedNextLevel());
    }
    IEnumerator DelayedNextLevel() {
        yield return wait;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
        yield return null;
    }

    public void GameOver() {
        OnSceneEnding();
        StartCoroutine(DelayedGameOver());
    }
    IEnumerator DelayedGameOver() {
        yield return wait;
        int gameOverIndex = SceneManager.sceneCountInBuildSettings - 1;
        SceneManager.LoadScene(gameOverIndex);
        yield return null;
    }

    public void Quit() {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}
