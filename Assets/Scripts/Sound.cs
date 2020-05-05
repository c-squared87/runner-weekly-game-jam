using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

    [HideInInspector]
    public AudioSource Source;

    public string Name;

    public AudioClip Clip;

    [Range (0, 1)] public float Volume;
    [Range (0.1f, 3)] public float Pitch;
    [Range (0, 1.1f)] public float Reverb;

    public bool Loop;

    // public void PlaySound () {
    //     if (Clip.Length == 1) {
    //         Source.clip = Clip[0];
    //     } else {
    //         int _rand = UnityEngine.Random.Range (0, Clip.Length);
    //         Source.clip = Clip[_rand];
    //     }

    //     Source.Play ();
    // }

}