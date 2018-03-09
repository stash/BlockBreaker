using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTweaker : MonoBehaviour {
    public Vector2 min;
    public Vector2 max;

    private void OnCollisionEnter2D(Collision2D collision) {
        BallController ball = collision.gameObject.GetComponent<BallController>();
        if (!ball) return;
        Vector2 tweak = new Vector2(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y)
        );
        ball.TweakVelocity(tweak);
    }
}
