﻿using System;
using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour {
    public static int breakableCount = 0;
    public static event Action OnDestroyed;

    public Sprite[] damages = new Sprite[0];
    public int maxHits => damages.Length + 1;
    public bool isBreakable { get; private set; }
    public AudioClip clip;

    private int timesHit;

    void Start() {
        timesHit = 0;
        isBreakable = (tag == "Breakable");
        if (isBreakable) breakableCount++;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (isBreakable) {
            timesHit++;
        } else {
            PlayClip(); // will be the "unbreakable" clip in this case
        }
    }

    void Update() {
        if (timesHit >= maxHits) {
            BreakBrick();
        } else if (timesHit > 0) {
            GetComponent<SpriteRenderer>().sprite = damages[timesHit - 1];
        }
    }

    void PlayClip() {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    void BreakBrick() {
        breakableCount--;
        PlayClip();
        Destroy(gameObject);
        OnDestroyed();
    }
}