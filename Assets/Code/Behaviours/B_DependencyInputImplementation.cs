using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class makes use of Global Input Manager to show how it should be handled
/// in other classes and proyects
/// </summary>
public class B_DependencyInputImplementation : MonoBehaviour
{
    #region ATTRIBUTES
    
    //GlobalInputActions.TestingMapActions testingMapActions;
    
    #endregion
    
    #region METHODS

    void Awake()
    {
        
    }

    void Start()
    {
        //_mainInteraction = M_GlobalInput.Instance.globalInputActions.TestingMap.MainInteraction;
        //_mainInteraction.performed += (InputAction.CallbackContext c) => MainInteraction();
        //testingMapActions = M_GlobalInput.Instance.globalInputActions.TestingMap;

        //testingMapActions.MainInteraction.performed += (InputAction.CallbackContext c) => MainInteraction();
        M_GlobalInput.Instance.globalInputActions.TestingMap.MainInteraction.performed += MainInteraction;
    }

    /// <summary>
    /// This method will be called whenever player presses the Main Interaction button from any
    /// input device (not only keyboard)
    /// </summary>
    /// <param name="c">Contains all info about the input action</param>
    void MainInteraction(InputAction.CallbackContext c)
    {
        Debug.Log("Main Interaction");
    }

    #endregion
}
