using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [System.Serializable]
    public class AudioClipName {
        public string name;
        public AudioClip audioClip;
    }

    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    public List<AudioClipName> clips;
    private AudioSource sourceSfx;
    private AudioSource sourceMusic;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }

        AudioSource[] sources = GetComponents<AudioSource>();
        sourceSfx = sources[0];
        sourceMusic = sources[1];
    }

    public static void PlaySFX(string sfxName) {
        if (!Instance) {
            return;
        }
        foreach (AudioClipName audioClipName in Instance.clips) {
            if (audioClipName.name == sfxName) {
                Instance.sourceSfx.PlayOneShot(audioClipName.audioClip);
                return;
            }
        }
    }

    public static void LoopMusic(string sfxName) {
        if (!Instance) {
            return;
        }
        foreach (AudioClipName audioClipName in Instance.clips) {
            if (audioClipName.name == sfxName) {
                Instance.sourceMusic.Stop();
                Instance.sourceMusic.clip = audioClipName.audioClip;
                Instance.sourceMusic.Play();
                return;
            }
        }
        
    }

    public void PauseMusic() {
        sourceMusic.Pause();
    }
}