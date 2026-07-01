using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Since it's byte, we can work with 8 flags at a time: 0000 0000
/// </summary>
[Flags]
public enum FlagsExample : byte
{
    Onboarding = 1 << 0,        // 0000 0001
    Step_1 = 1 << 1,            // 0000 0010
    Step_2 = 1 << 2,            // 0000 0100
    FinalStage = 1 << 3,        // 0000 1000
    Credits = 1 << 4,           // 0001 0000
}

/// <summary>
/// Generic implementation of FlagSystem.
/// This manager allows us to modify each different flag independently without worrying about
/// following any specific order, checking global state, and going back wherever it's needed
/// </summary>
public class M_FlagSystemImplementation : FlagSystem<FlagsExample>
{
    #region ATTRIBUTES

    public FlagsExample _currentStatus;
    
    [Header("Editable values")]

    [SerializeField] Key RandomKey_1;
    [SerializeField] Key RandomKey_2;

    #endregion

    #region METHODS
    
    void Update()
    {
        if(Keyboard.current.allKeys[(int)RandomKey_1 - 1].wasPressedThisFrame)
        {
            SwitchStates(FlagsExample.Step_1, FlagsExample.Step_2);
        }
        if (Keyboard.current.allKeys[(int)RandomKey_2 - 1].wasPressedThisFrame)
        {
            SwitchStates(FlagsExample.Onboarding, FlagsExample.Credits);
        }
    }

    #region FlagSystem Implementation

    internal override void SetState(FlagsExample givenFlags)
    {
        _currentStatus |= givenFlags;
    }

    internal override void ClearState(FlagsExample givenFlags)
    {
        _currentStatus &= ~givenFlags;
    }

    internal override void ToggleState(FlagsExample givenFlags)
    {
        _currentStatus ^= givenFlags;
    }

    internal override void SwitchStates(FlagsExample settingFlags, FlagsExample clearingFlags)
    {
        _currentStatus |= settingFlags;
        _currentStatus &= ~clearingFlags;
    }

    internal override void ClearAllStates()
    {
        _currentStatus = 0;
    }

    internal override bool CheckState(FlagsExample givenFlags)
    {
        return _currentStatus.HasFlag(givenFlags);
    }

    #endregion
    
    #endregion
}
