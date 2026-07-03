using Code.Utils;
using UnityEngine;

public class M_Debug : Singleton<M_Debug>
{
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
