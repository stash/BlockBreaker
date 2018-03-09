using System;
using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour {
    public static int breakableCount = 0;
    public static event Action OnDestroyed;

    public Sprite[] damages = new Sprite[0];
    public int maxHits => damages.Length + 1;
    public bool isBreakable { get; private set; }
    public AudioClip breakClip;
    public AudioClip hitClip;

    private int timesHit;

    void Start() {
        timesHit = 0;
        isBreakable = (tag == "Breakable");
        if (isBreakable) breakableCount++;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (isBreakable) {
            timesHit++;
            if (timesHit >= maxHits) {
                BreakBrick();
            } else {
                GetComponent<SpriteRenderer>().sprite = damages[timesHit - 1];
                PlayHitClip();
            }
        } else {
            PlayHitClip(); // will be the "unbreakable" clip in this case
        }
    }

    void BreakBrick() {
        breakableCount--;
        PlayBreakClip();
        Destroy(gameObject);
        OnDestroyed();
    }

    void PlayBreakClip() {
        AudioSource.PlayClipAtPoint(breakClip, transform.position);
    }

    void PlayHitClip() {
        AudioSource.PlayClipAtPoint(hitClip, transform.position);
    }
}