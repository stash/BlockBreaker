using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void NewGame() {
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
