using UnityEngine;

public class LoseCollider : MonoBehaviour {
    public SceneController sceneController;

    void OnTriggerEnter2D(Collider2D collision) {
        sceneController.LoadScene("GameOver");
    }
}
