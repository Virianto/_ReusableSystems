using System;
using System.Threading.Tasks;

/// <summary>
/// Specific command implementation example
/// </summary>
public class TogglePowerCommand : ICommand
{
    #region ATTRIBUTES
        
    public bool IsParallelizable
    {
        get;
        set;
    }

    public event Action OnCommandStarted;
    public event Action OnCommandFinished;

    B_Lightbulb myLight;

    #endregion

    #region METHODS

    /// <summary>
    /// Constructor del comando concreto que permite alimentarlo con referencias para que pueda hacer uso
    /// de sus m�todos
    /// </summary>
    public TogglePowerCommand(B_Lightbulb lightRef)
    {
        myLight = lightRef;
    }

    async Task ICommand.Undo()
    {
        OnCommandStarted?.Invoke();
        await myLight.TogglePower();
        OnCommandFinished?.Invoke();
    }

    async Task ICommand.Execute()
    {
        OnCommandStarted?.Invoke();
        await myLight.TogglePower();
        OnCommandFinished?.Invoke();
    }

    public void Pause()
    {
        myLight.PauseCurrentAnimation();
    }

    public void Resume()
    {
        myLight.ResumeCurrentAnimation();
    }

    public void Cancel()
    {
        myLight.CancelCurrentAnimation();
    }

    public void Finish()
    {
        myLight.FinishCurrentAnimation();
    }

    #endregion
}