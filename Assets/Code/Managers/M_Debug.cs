using Code.Utils;
using UnityEngine;

/// <summary>
/// Debug Manager
/// This class is responsible for catching all developer debug messages and make them
/// accessible to any UI through events so the messages are visible outside the editor
/// </summary>
public class M_Debug : Singleton<M_Debug>
{
    // TO DOs:
    // - Add a structure for debug messages allowing different types (SO customizable)
    // - Create necessary events to communicate debug messages to any listener
    // - Filter, format and build debug messages when needed before launching events
    
    #region ATTRIBUTES

    //public TMP_Text debugText;
    string _debugString = "";

    #endregion
    
    #region METHODS

    public void AddToDebug(string newText)
    {
        _debugString += "- " + newText + "\n";
        //debugText.text = debugString;

        Debug.Log(newText);
    }

    #endregion
}
