using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTweaker : MonoBehaviour {
    public float magnitude = 0.05f;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (magnitude <= 0f) return;

        Vector2 point;
        if (!Util.FirstCollisionPoint(collision, out point))
            return;

        // speed up towards the center of the field
        Vector2 tweak = Util.centerField - point;
        tweak.Normalize();
        tweak *= magnitude;

        BallController ball = collision.gameObject.GetComponent<BallController>();
        if (!ball) return;
        ball.TweakVelocity(tweak);
    }
}
