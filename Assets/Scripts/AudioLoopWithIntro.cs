using UnityEngine;

public class AudioLoopWithIntro : MonoBehaviour {
    public AudioSource introSource;
    public AudioSource loopSource;

    static AudioLoopWithIntro instance;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start() {
        DontDestroyOnLoad(gameObject);

        double introEnd = AudioSettings.dspTime + introSource.clip.length;
        // start the intro clip immediately
        introSource.PlayScheduled(AudioSettings.dspTime);
        introSource.SetScheduledEndTime(introEnd);

        // schedule the loop clip to begin as soon as the intro clip ends.
        loopSource.PlayScheduled(introEnd);
    }
}