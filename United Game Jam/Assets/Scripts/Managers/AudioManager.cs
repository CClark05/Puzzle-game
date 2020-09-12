using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        
        instance = this;
       
       

      foreach (var s in sounds)
      {
          s.source = gameObject.AddComponent<AudioSource>();
          s.source.clip = s.clip;
          s.source.volume = s.volume;
          s.source.pitch = s.pitch;
          s.source.outputAudioMixerGroup = s.mixer;
                
      }
    }

    public void Play(string name)
    {
       var s = Array.Find(sounds, sound => sound.name == name);
       s.source.Play();

    }
    

}
