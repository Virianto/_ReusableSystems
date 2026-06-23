using System.Collections.Generic;

/// <summary>
/// Bridge class between the INITIAL CLIENT and the FINAL RECEIVER of the command
/// </summary>
public class CommandInvoker
{
	#region ATTRIBUTES

	Stack<ICommand> executedCommandsStack;
	Queue<ICommand> pendingCommandsQueue;

	ICommand currentCommand;

	bool currentlyExecuting;

	#endregion
	
	#region METHODS
	
	public CommandInvoker()
    {
		executedCommandsStack = new ();
		pendingCommandsQueue = new ();
    }

	public void AddCommand(ICommand newCommand)
    {
        if (newCommand.IsParallelizable)
        {
			newCommand.Execute();
			//executedCommandsStack.Push(newCommand);
        }
        else
        {
			pendingCommandsQueue.Enqueue(newCommand);
			CheckForNextPendingCommand();
		}		
	}

	void CheckForNextPendingCommand()
    {
		if(pendingCommandsQueue.Count > 0 && !currentlyExecuting)
        {
			currentCommand = pendingCommandsQueue.Dequeue();

			currentCommand.OnCommandStarted += ManageCommandStarted;
			currentCommand.OnCommandFinished += ManageCommandFinished;
			currentCommand.Execute();
			executedCommandsStack.Push(currentCommand);
		}		
	}

	public void PauseCurrentCommand()
    {
		currentCommand.Pause();
    }

	public void ResumeCurrentCommand()
    {
		currentCommand.Resume();
    }

	public void CancelCurrentCommand()
    {
		currentCommand.Cancel();
    }

	public void FinishCurrentCommand()
    {
		currentCommand.Finish();
    }

	public void UndoAllCommandsParallel()
    {
		int totalCommands = executedCommandsStack.Count;
		for (int e = 0; e < totalCommands; ++e)
        {
			ICommand latestCommand = executedCommandsStack.Pop();
			latestCommand.Undo();
		}
    }

    public void UndoLastCommand()
    {
		if(executedCommandsStack.Count > 0)
        {
			ICommand latestCommand = executedCommandsStack.Pop();
			latestCommand.Undo();
		}		
    }

	void ManageCommandStarted()
    {
		currentlyExecuting = true;
		//Debug.Log("Command launched");		
	}

	void ManageCommandFinished()
	{
		currentlyExecuting = false;
		//Debug.Log("Command finished executing");
		CheckForNextPendingCommand();
	}

	#endregion
}
