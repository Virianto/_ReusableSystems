using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class makes use of Global Input Manager to show how it should be handled
/// in other classes and proyects
/// </summary>
public class B_InputExampleImplementation : MonoBehaviour
{
    #region ATTRIBUTES
    
    GlobalInputActions.TestingMapActions testingMapActions;
    
    #endregion
    
    #region METHODS

    void Awake()
    {
        
    }

    void Start()
    {
        testingMapActions = M_GlobalInput.Instance.globalInputActions.TestingMap;
        
        testingMapActions.MainInteraction.performed += (InputAction.CallbackContext c) => MainInteraction();
    }

    void MainInteraction()
    {
        Debug.Log("Main Interaction");
    }

    #endregion
}
