using UnityEngine;

public class Brick : MonoBehaviour {
    public int maxHits = 0;

    private int timesHit;

    void Start() {
        timesHit = 0;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        BallController ball = collision.gameObject.GetComponent<BallController>();
        if (ball == null) return;
        timesHit++;
    }

    void Update() {
        if (timesHit >= maxHits) {
            DestroyObject(gameObject);
        }
    }
}