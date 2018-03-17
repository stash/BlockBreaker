using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    public GameObject clipPrefab;
    public float panFactor = 0.75f;

    public void PlayPannedEffectClip(AudioClip clip, float x) {
        GameObject clone = Instantiate(clipPrefab);
        DontDestroyOnLoad(clone);

        float pan = (x / Util.fieldWidth) - 1f;
        Debug.Log("Playing clip at x " + x + " with pan " + pan);
        AudioSource source = clone.GetComponent<AudioSource>();
        source.clip = clip;
        source.panStereo = pan * panFactor;
        source.Play();
        StartCoroutine(CleanupSource(source, clone));
    }

    IEnumerator CleanupSource(AudioSource source, GameObject clone) {
        yield return new WaitForSeconds(source.clip.length + 0.1f);
        Destroy(clone);
        yield return null;
    }
}
