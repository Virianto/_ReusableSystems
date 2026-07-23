using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleAudioClipConfig", menuName = "Scriptable Objects/D_SingleAudioClip")]
public class SO_SingleAudioClipConfig : ScriptableObject
{
    public D_SingleAudioClip data;
}

[Serializable]
public struct D_SingleAudioClip
{
    [Header("Audio data")]

    public AudioGroup mixerChannel;

    public AudioClip audioClip;

    public bool isOneShot;

    public bool useObjectTransformAsOrigin;
}
