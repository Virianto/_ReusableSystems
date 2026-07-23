using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SingleDaytimeConfig", menuName = "Scriptable Objects/D_SingleDaytime", order = 1)]
public class SO_SingleDaytimeConfig : ScriptableObject
{
    public D_SingleDaytime data;
}

public enum Daytime : byte
{
    Dawn,
    Midday,
    Twilight,
    Midnight
}

[Serializable]
public struct D_SingleDaytime
{
    [Header("Day Time")]

    public Daytime daytime;

    [Header("Linked values")]

    [Space(5)]

    [Header("Main Directional Light Data")]

    [Range(1000, 22000)]
    public float mainLightTemperature;

    public Vector3 lightRotation;

    public float lightIntensity;

    [Space(5)]

    [Header("Skybox Material Data")]

    [Range(0, 1)]
    public float sunOrMoonSize;

    [Range(1, 10)]
    public float sunOrMoonSizeConvergence;

    [Range(0, 3.2f)]
    public float atmosphereThickness;

    public Color skyTint;

    public Color groundColor;

    [Range(0, 8)]
    public float exposure;
}