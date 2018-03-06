using System;
using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour {
    public Sprite[] damages = new Sprite[0];
    public int maxHits => damages.Length + 1;

    private int timesHit;

    void Start() {
        timesHit = 0;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        BallController ball = collision.gameObject.GetComponent<BallController>();
        if (ball == null) return;

        if (tag == "Breakable")
            timesHit++;
    }

    void Update() {
        if (timesHit >= maxHits) {
            DestroyObject(gameObject);
        } else if (timesHit > 0) {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = damages[timesHit - 1];
        }
    }
}