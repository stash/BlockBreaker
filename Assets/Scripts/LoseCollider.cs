using System;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    public static event Action OnBallLeftArea;
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D collision) {
        FindObjectOfType<AudioController>().PlayPannedEffectClip(clip, transform.position.x);
        OnBallLeftArea();
    }
}
