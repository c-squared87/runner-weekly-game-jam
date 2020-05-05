using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager Instance;

    private void Start () {

        if (Instance == null) { Instance = this; }
        if (Instance != this) { Destroy (gameObject); return; }

        DontDestroyOnLoad (this.gameObject);

        foreach (Sound _sound in sounds) {

            _sound.Source = gameObject.AddComponent<AudioSource> ();

            _sound.Source.clip = _sound.Clip;
            _sound.Source.volume = _sound.Volume;
            _sound.Source.pitch = _sound.Pitch;
            _sound.Source.loop = _sound.Loop;
            _sound.Source.reverbZoneMix = _sound.Reverb;
        }

        sounds[0].Source.Play ();
    }

    private void OnEnable () {
        EventsManager.ADD_PlayerHitListener (PlayerHitSound);
    }
    private void OnDisable () {
        EventsManager.REMOVE_PlayerHitListener (PlayerHitSound);
    }

    private void PlayerHitSound () {

        Sound _s = Array.Find (sounds, sound => sound.Name == "Impact1");
        Sound _s2 = Array.Find (sounds, sound => sound.Name == "Impact3");

        if (_s == null) {
            Debug.LogWarning ("Sound " + "Impact" + " Was Not Found.");
            return;
        }
        _s.Source.Play ();
        _s2.Source.Play ();
    }
}