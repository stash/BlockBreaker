using UnityEngine;

public class AudioLoopWithIntro : MonoBehaviour {
    public AudioSource introSource;
    public AudioSource loopSource;
    public float webGLVolume = 0.25f;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        double introEnd = AudioSettings.dspTime + introSource.clip.length;
        // start the intro clip immediately
        introSource.PlayScheduled(AudioSettings.dspTime);
        introSource.SetScheduledEndTime(introEnd);

        // schedule the loop clip to begin as soon as the intro clip ends.
        loopSource.PlayScheduled(introEnd);

#if UNITY_WEBGL || LIMITED_AUDIO
        introSource.volume = webGLVolume;
        loopSource.volume = webGLVolume;
#endif
    }
}