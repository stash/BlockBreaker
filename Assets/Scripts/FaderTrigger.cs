using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderTrigger : MonoBehaviour {
    Animator animator;

    readonly int fadeTrigger = Animator.StringToHash("Fade");

    void Start() {
        Debug.Log("FaderTrigger Start");
        animator = GetComponent<Animator>();
        SceneController.OnSceneEnding += SceneController_OnSceneEnding;
    }

    void OnDestroy() {
        SceneController.OnSceneEnding -= SceneController_OnSceneEnding;
    }

    void SceneController_OnSceneEnding() {
        animator.SetTrigger(fadeTrigger);
    }
}
