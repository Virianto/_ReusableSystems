using System;
using System.Threading.Tasks;

/// <summary>
/// Interfaz que implementarán todos los comandos concretos para facilitarle la tarea
/// al invocador de comandos (que se limita a gestionar una lista, pila o cola de comandos)
/// </summary>
public interface ICommand
{
    #region EVENTS

    event Action OnCommandStarted;
    event Action OnCommandFinished;

    #endregion

    public bool IsParallelizable
    {
        get;
        set;
    }

    #region TASKS

    Task Execute();

    void Pause();

    void Resume();

    void Cancel();

    void Finish();

    Task Undo();

    #endregion
}
