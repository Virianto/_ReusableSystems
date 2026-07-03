using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugMsgConfig", menuName = "Scriptable Objects/D_DebugMsg", order = 1)]
public class SO_DebugMsgConfig : ScriptableObject
{
    public D_DebugMsg configData;
}

public enum DebugMsgType : byte
{
    Info,
    Warning,
    Error
}

[Serializable]
public struct D_DebugMsg
{
    public DebugMsgType msgType;
    
    // Color
    // Font
    // Font Size
}