using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{

    public AudioClip clip;
    public AudioMixerGroup mixer;
    public string name;
    [Range(0, 1f)]
    public float volume;
    [Range(0.1f, 3)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
    
}
