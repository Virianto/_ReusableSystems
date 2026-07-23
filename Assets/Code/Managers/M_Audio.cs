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

    #endregion
    
    #region METHODS

    

    #endregion
}
