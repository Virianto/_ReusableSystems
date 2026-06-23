using System;
using UnityEngine;

/// <summary>
// Parent class for all managers that require the use of a flags enumeration system.
/// The methods are internal abstract because they cannot be implemented in this class without first knowing the definition of T.
/// </summary>
/// <typeparam name="T">This shall be "Enum [flags]" defined in children class</typeparam>
public abstract class M_FlagSystem<T> : MonoBehaviour where T : Enum
{
    #region ATTRIBUTES

    internal delegate void FlagsChanged(T newFlagsValue);
    internal FlagsChanged OnFlagsChanged;

    protected T _selfFlags;

    internal T SelfFlags
    {
        get => _selfFlags;
        set
        {
            _selfFlags = value;
            OnFlagsChanged?.Invoke(_selfFlags);
        }
    }

    #endregion

    #region METHODS

    /// <summary>
    /// Sets given enum to value = 1
    /// </summary>
    /// <param name="givenFlags">Name for the state we want to switch</param>
    internal abstract void SetState(T givenFlags);

    /// <summary>
    /// Sets given enum to value = 0
    /// </summary>
    /// <param name="givenFlags">Name for the state we want to switch</param>
    internal abstract void ClearState(T givenFlags);

    /// <summary>
    /// Sets given enum to its inversed value (0 -> 1 or 1 -> 0)
    /// </summary>
    /// <param name="givenFlags"></param>
    internal abstract void ToggleState(T givenFlags);

    /// <summary>
    /// Modifies several flags at the same time ensuring the event is called only once
    /// </summary>
    /// <param name="settingFlags">These will be set to 1</param>
    /// <param name="clearingFlags">These will be set to 0</param>
    internal abstract void SwitchStates(T settingFlags, T clearingFlags);

    /// <summary>
    /// Sets all possible states values back to 0
    /// </summary>
    internal abstract void ClearAllStates();

    /// <summary>
    /// Used to check flags 1 by 1 or grouped if necessary
    /// </summary>
    /// <param name="givenFlags"></param>
    /// <returns></returns>
    internal abstract bool CheckState(T givenFlags);

    #endregion
}
