using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    const float transitionDelay = 2f;

    WaitForSeconds wait;

    void Start() {
        wait = new WaitForSeconds(transitionDelay);
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
        StartCoroutine(DelayedNextLevel());
    }
    IEnumerator DelayedNextLevel() {
        yield return wait;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
        yield return null;
    }

    public void GameOver() {
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
