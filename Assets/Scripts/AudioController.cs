using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public GameObject clipPrefab;
    public float panFactor = 0.75f;
    public float webGLVolume = 1f;

    public void PlayPannedEffectClip(AudioClip clip, float x) {
#if UNITY_WEBGL || LIMITED_AUDIO
        // Web Audio API doesn't support stereo panning and the whole mixing thing doesn't work great, so just fall back to PlayAtPoint
        JustPlayAtPoint(clip, x);
#else
        GameObject clone = Instantiate(clipPrefab);
        DontDestroyOnLoad(clone);

        float pan = (x / Util.fieldWidth) - 1f;
        Debug.Log("Playing clip at x " + x + " with pan " + pan);
        AudioSource source = clone.GetComponent<AudioSource>();
        source.clip = clip;
        source.panStereo = pan * panFactor;
        source.Play();
        StartCoroutine(CleanupSource(source, clone));
#endif
    }

    void JustPlayAtPoint(AudioClip clip, float x) {
        Vector3 point = new Vector3(x, 0f, 0f);
        AudioSource.PlayClipAtPoint(clip, point, webGLVolume);
    }

    IEnumerator CleanupSource(AudioSource source, GameObject clone) {
        yield return new WaitForSeconds(source.clip.length + 0.1f);
        Destroy(clone);
        yield return null;
    }
}
