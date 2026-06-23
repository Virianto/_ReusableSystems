using System;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Specific command implementation example
/// </summary>
public class ChangeColorCommand : ICommand
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

    Color previousColor;

    

    #endregion

    #region METHODS

    /// <summary>
    /// Constructor del comando concreto que permite alimentarlo con la informaci�n que requerir�
    /// el m�todo Execute en sus par�metros
    /// </summary>
    public ChangeColorCommand(B_Lightbulb lightRef)
    {
        myLight = lightRef;
        previousColor = lightRef.GetComponent<Light>().color;
    }

    async Task ICommand.Undo()
    {
        OnCommandStarted?.Invoke();
        await myLight.SetLightColor(previousColor);
        OnCommandFinished?.Invoke();
    }

    async Task ICommand.Execute()
    {
        OnCommandStarted?.Invoke();
        await myLight.SetRandomLightColor();
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
