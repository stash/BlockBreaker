using System;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    public static Action OnBallLeftArea;
    void OnTriggerEnter2D(Collider2D collision) {
        OnBallLeftArea();
    }
}
