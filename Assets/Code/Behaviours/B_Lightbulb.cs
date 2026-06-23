using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine.InputSystem;

/// <summary>
/// INITIAL CLIENT (Because it catches user Input) and FINAL RECEIVER (Because it executes changes)
/// </summary>

public class B_Lightbulb : MonoBehaviour
{
    #region ATTRIBUTES

    #region Events

    //public event Action OnTogglePowerStarted;
    //public event Action OnTogglePowerFinished;

    #endregion

    [Header("Editable values")]

	[SerializeField] Key togglePowerKey;
    [SerializeField] Key changeColorKey;
    
    [Space(5)]
    
    [SerializeField] Key pauseKey;
    [SerializeField] Key resumeKey;
    [SerializeField] Key cancelKey;
    [SerializeField] Key finishKey;

    [Space(5)]

    [SerializeField] Key undoKey;

    Tween animationTween;

    CommandInvoker myCommandInvoker;

    Light myLight;

    bool isLightOn;

    #endregion

    #region METHODS
    void Awake()
    {
        myLight = GetComponent<Light>();
        
        myCommandInvoker = new CommandInvoker();
    }

    void Update()
    {
        if(Keyboard.current.allKeys[(int)togglePowerKey - 1].wasPressedThisFrame)
        {
            ICommand toggleCommand = new TogglePowerCommand(this);            
            myCommandInvoker.AddCommand(toggleCommand);
        }
        if (Keyboard.current.allKeys[(int)changeColorKey - 1].wasPressedThisFrame)
        {
            ICommand colorCommand = new ChangeColorCommand(this);
            myCommandInvoker.AddCommand(colorCommand);
        }

        if (Keyboard.current.allKeys[(int)pauseKey - 1].wasPressedThisFrame)
        {
            myCommandInvoker.PauseCurrentCommand();
        }
        if (Keyboard.current.allKeys[(int)resumeKey - 1].wasPressedThisFrame)
        {
            myCommandInvoker.ResumeCurrentCommand();
        }
        if (Keyboard.current.allKeys[(int)cancelKey - 1].wasPressedThisFrame)
        {
            myCommandInvoker.CancelCurrentCommand();
        }
        if (Keyboard.current.allKeys[(int)finishKey - 1].wasPressedThisFrame)
        {
            myCommandInvoker.FinishCurrentCommand();
        }

        if (Keyboard.current.allKeys[(int)undoKey - 1].wasPressedThisFrame)
        {            
            myCommandInvoker.UndoLastCommand();
        }
    }

    public void PauseCurrentAnimation()
    {
        animationTween.Pause();
    }

    public void ResumeCurrentAnimation()
    {
        animationTween.Play();
    }

    public void CancelCurrentAnimation()
    {
        animationTween.Kill();
    }

    public void FinishCurrentAnimation()
    {
        animationTween.Complete(true);
    }

    public async Task TogglePower()
    {
        isLightOn = !isLightOn;

        float destIntensity = isLightOn ? 15 : 0;

        Debug.Log("Task iniciada");

        animationTween = myLight.DOIntensity(destIntensity, 3);

        await animationTween.AsyncWaitForCompletion();
        Debug.Log("Task terminada");        
    }

    public async Task SetLightColor(Color newColor)
    {
        Debug.Log("Task iniciada");

        animationTween = myLight.DOColor(newColor, 3);
        await animationTween.AsyncWaitForCompletion();

        Debug.Log("Task terminada");
    }

    public async Task SetRandomLightColor()
    {
        Debug.Log("Task iniciada");

        Color randomColor = Random.ColorHSV(0, 1, 1, 1, 0.5f, 1);
        animationTween = myLight.DOColor(randomColor, 3);

        await animationTween.AsyncWaitForCompletion();

        Debug.Log("Task terminada");
    }

    #endregion
}
