using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionPlayClip : MonoBehaviour {
    public AudioClip clip;

    void OnCollisionEnter2D(Collision2D collision) {
        PlayClip();
    }
    void OnCollisionEnter(Collision collision) {
        PlayClip();
    }

    void PlayClip() {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
