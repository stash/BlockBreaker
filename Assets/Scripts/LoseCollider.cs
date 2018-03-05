using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    public SceneController sceneController;

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("boop");
        sceneController.LoadScene("GameOver");
    }
}
