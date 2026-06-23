using System;

[Flags]
public enum FlagsExample : short
{
    Onboarding = 1 << 0,
    Step_1 = 1 << 1,
    Step_2 = 1 << 2,
    FinalStage = 1 << 3,
    Credits = 1 << 4,

}

public class M_FlagSystemImplementation : FlagSystem<FlagsExample>
{
    #region ATTRIBUTES

    public FlagsExample _currentStatus;

    #endregion

    #region METHODS
 
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
}
