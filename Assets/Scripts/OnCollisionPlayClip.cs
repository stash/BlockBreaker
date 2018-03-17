using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionPlayClip : MonoBehaviour {
    public AudioClip clip;

    void OnCollisionEnter2D(Collision2D collision) {
        Vector2 point;
        if (Util.FirstCollisionPoint(collision, out point)) {
            PlayClip(point);
        } else {
            PlayClip(transform.position);
        }
    }

    void PlayClip(Vector2 point) {
        FindObjectOfType<AudioController>().PlayPannedEffectClip(clip, point.x);
    }
}
