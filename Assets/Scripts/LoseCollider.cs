using UnityEngine;

public class LoseCollider : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<SceneController>().GameOver();
    }
}
