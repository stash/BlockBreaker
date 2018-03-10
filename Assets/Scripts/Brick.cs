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
    public GameObject[] breakVFX = new GameObject[0];
    public float breakSaturation = 0.5f;

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
        PlayBreakVFX();
        Destroy(gameObject);
        OnDestroyed();
    }

    void PlayBreakClip() {
        AudioSource.PlayClipAtPoint(breakClip, transform.position);
    }

    void PlayHitClip() {
        AudioSource.PlayClipAtPoint(hitClip, transform.position);
    }

    void PlayBreakVFX() {
        foreach (var prefab in breakVFX) {
            GameObject vfx = Instantiate(prefab, transform.position, Quaternion.identity);
            ParticleSystem.MainModule main = vfx.GetComponent<ParticleSystem>().main;
            float h, s, v;
            Color c = GetComponent<SpriteRenderer>().color;
            Color.RGBToHSV(c, out h, out s, out v);
            s *= breakSaturation;
            main.startColor = Color.HSVToRGB(h, s, v);
        }
        
    }
}