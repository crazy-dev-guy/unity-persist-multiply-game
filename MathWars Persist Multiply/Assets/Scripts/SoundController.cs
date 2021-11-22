using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {

    public static SoundController Instance { get; private set; }
    public List<AudioSource> musicListAudioSource;

    public List<AudioSource> soundListAudioSource;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }
    
    public bool ToggleMusic() {
        if (musicListAudioSource[0].mute) {
            foreach (AudioSource audioSource in musicListAudioSource) {
                audioSource.mute = false;
            }
            return true;
        } else {
            foreach (AudioSource audioSource in musicListAudioSource) {
                audioSource.mute = true;
            }
            return false;
        }
    }
    
    public bool ToggleSound() {
        if (soundListAudioSource[0].mute) {
            foreach (AudioSource audioSource in soundListAudioSource) {
                audioSource.mute = false;
            }
            return true;
        } else {
            foreach (AudioSource audioSource in soundListAudioSource) {
                audioSource.mute = true;
            }
            return false;
        }
    }

    public void PlayMusicByIndex(int index) {
        foreach (AudioSource audioSource in musicListAudioSource) {
            audioSource.Stop();
        }
        musicListAudioSource[index].Play();
    }

    public void PlaySoundByIndex(int index) {
        soundListAudioSource[index].Play();
    }
}
