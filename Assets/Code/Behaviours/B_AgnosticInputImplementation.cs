using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class ignores the Global Input Manager and uses Input System directly
/// </summary>
public class B_AgnosticInputImplementation : MonoBehaviour
{
    #region ATTRIBUTES

    
    
    #endregion
    
    #region METHODS

    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Debug.Log("Mouse position: " + mousePosition);

        // This code will execute ONLY whenever player presses the 'E' key on Keyboard
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E key pressed");
        }

        // This code will execute ONLY whenever player holds the 'W' key on Keyboard
        if (Keyboard.current.wKey.isPressed)
        {
            Debug.Log("W key is being pressed");           
        }
    }

    #endregion
}
