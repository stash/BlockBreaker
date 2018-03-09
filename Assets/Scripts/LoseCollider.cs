using System;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    public static event Action OnBallLeftArea;
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D collision) {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        OnBallLeftArea();
    }
}
