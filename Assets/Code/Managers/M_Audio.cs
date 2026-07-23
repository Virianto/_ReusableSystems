using System;
using System.Collections.Generic;
using Code.Utils;
using UnityEngine;
using UnityEngine.Audio;

public enum AudioGroup : byte
{
    Dialogs,
    FX,
    Music,
    Sounds,
    Other
}

/// <summary>
/// Audio Manager
/// </summary>
public class M_Audio : Singleton<M_Audio>
{
    #region ATTRIBUTES
    
    [Header("External References")]

    [SerializeField] AudioMixer globalAudioMixer;

    [SerializeField] GameObject dialogAudioSourceObject;
    [SerializeField] GameObject fxAudioSourceObject;
    [SerializeField] GameObject musicAudioSourceObject;
    [SerializeField] GameObject soundsAudioSourceObject;
    [SerializeField] GameObject otherAudioSourceObject;
    
    Dictionary<AudioGroup, GameObject> _audioSources;

    #endregion
    
    #region METHODS

    void Awake()
    {
        _audioSources = new Dictionary<AudioGroup, GameObject>
        {
            { AudioGroup.Dialogs, dialogAudioSourceObject },
            { AudioGroup.FX, fxAudioSourceObject },
            { AudioGroup.Music, musicAudioSourceObject },
            { AudioGroup.Sounds, soundsAudioSourceObject },
            { AudioGroup.Other, otherAudioSourceObject }
        };
    }

    #endregion
}
